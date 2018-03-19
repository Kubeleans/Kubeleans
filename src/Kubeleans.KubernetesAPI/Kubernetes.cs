using Kubeleans.KubernetesAPI.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kubeleans.KubernetesAPI
{
    internal class Kubernetes : IKubernetes
    {
        private static readonly Encoding _encoding = Encoding.UTF8;
        private static readonly IReadOnlyList<CustomResourceDefinition> _emptyCustomResourceDefinitionList = new List<CustomResourceDefinition>();

        private const string CRD_ENDPOINT = "/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions";
        private const string MEDIA_TYPE = "application/json";
        private const string SERVICE_ACCOUNT_PATH = "/var/run/secrets/kubernetes.io/serviceaccount/";
        private const string SERVICE_ACCOUNT_NAMESPACE_FILENAME = "namespace";
        private const string SERVICE_ACCOUNT_TOKEN_FILENAME = "token";
        private const string SERVICE_ACCOUNT_ROOTCA_FILENAME = "ca.crt";
        private const string BEGIN_CERT_LINE = "-----BEGIN CERTIFICATE-----";
        private const string END_CERT_LINE = "-----END CERTIFICATE-----";
        private const string RETURN_CHAR = "\r";
        private const string NEWLINE_CHAR = "\n";
        private const string IN_CLUSTER_KUBE_ENDPOINT = "https://kubernetes.default.svc.cluster.local";
        internal const string KUBELEANS_GROUP = "kubeleans.io";
        private const string KUBELEANS_NAMESPACE = "kubeleans";

        private readonly ILogger _logger;
        private readonly string _namespace;
        private readonly HttpClient _client;
        private readonly X509Certificate2 _rootCertificate;

        private static readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Culture = CultureInfo.InvariantCulture,
            Converters = new[]
            {
                new StringEnumConverter(true)
            },
#if DEBUG
            Formatting = Formatting.Indented
#else
            Formatting = Formatting.None
#endif
        };

        public Kubernetes(
            IOptions<KubernetesOptions> options,
            ILoggerFactory loggerFactory,
            HttpClientHandler httpClientHandler = null)
        {
            this._logger = loggerFactory?.CreateLogger<Kubernetes>();

            var namespaceFilePath = Path.Combine(SERVICE_ACCOUNT_PATH, SERVICE_ACCOUNT_NAMESPACE_FILENAME);

            if (!File.Exists(namespaceFilePath))
            {
                this._logger.LogWarning($"Namespace file {namespaceFilePath} wasn't found. Are we running in a pod? If you are running unit tests outside a pod, please create the test namespace '{KUBELEANS_NAMESPACE}'.");

                this._namespace = KUBELEANS_NAMESPACE;
            }
            else
            {
                this._namespace = File.ReadAllText(namespaceFilePath);
            }

            var endpointUri = new Uri(string.IsNullOrWhiteSpace(options.Value.APIEndpoint) ? IN_CLUSTER_KUBE_ENDPOINT : options.Value.APIEndpoint);

            var certificateData = default(string);

            if (string.IsNullOrWhiteSpace(options.Value.Certificate))
            {
                var rootCertificateFilePath = Path.Combine(SERVICE_ACCOUNT_PATH, SERVICE_ACCOUNT_ROOTCA_FILENAME);

                if (File.Exists(rootCertificateFilePath))
                {
                    certificateData = File.ReadAllText(rootCertificateFilePath);
                }
                else
                {
                    this._logger?.LogWarning($"Root Certificate file {rootCertificateFilePath} wasn't found, no certificate will be used.");
                }
            }

            if (!string.IsNullOrWhiteSpace(certificateData))
            {
                certificateData = certificateData
                    .Replace(BEGIN_CERT_LINE, string.Empty)
                    .Replace(END_CERT_LINE, string.Empty)
                    .Replace(RETURN_CHAR, string.Empty)
                    .Replace(NEWLINE_CHAR, string.Empty);

                this._rootCertificate = new X509Certificate2(Convert.FromBase64String(certificateData));
            }

            var handler = httpClientHandler;

            if (handler == null)
            {
                handler = new HttpClientHandler();

                // If the base url is a secure one, install a certificate handler if we've a root certificate configured.
                if (endpointUri.Scheme == "https" && this._rootCertificate != null)
                {
                    handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, serverCertificate, chain, sslPolicyErrors) =>
                    {
                        // If the certificate is a valid, signed certificate, return true.
                        if (sslPolicyErrors == SslPolicyErrors.None)
                        {
                            return true;
                        }

                        // If there are errors in the certificate chain, look at each error to determine the cause.
                        if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) != 0)
                        {
                            chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                            // add all your extra certificate chain
                            chain.ChainPolicy.ExtraStore.Add(this._rootCertificate);
                            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

                            var isValid = chain.Build(serverCertificate);

                            return isValid;
                        }

                        // In all other cases, return false.
                        return false;
                    };
                }
            }

            this._client = new HttpClient(handler)
            {
                BaseAddress = endpointUri
            };

            var bearerToken = options.Value.APIToken;

            // If no apiToken was passed in, then try to load from file if exists.
            if (string.IsNullOrWhiteSpace(bearerToken))
            {
                var tokenFilePath = Path.Combine(SERVICE_ACCOUNT_PATH, SERVICE_ACCOUNT_TOKEN_FILENAME);

                if (File.Exists(tokenFilePath))
                {
                    bearerToken = File.ReadAllText(tokenFilePath);
                }
                else
                {
                    this._logger?.LogWarning($"Token file {tokenFilePath} wasn't found, no API token will be used.");
                }
            }

            if (!string.IsNullOrWhiteSpace(bearerToken))
            {
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            }
        }

        #region Custom Objects

        public async Task<TObject> CreateCustomObject<TObject>(string version, string plural, TObject obj) where TObject : CustomObject
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrWhiteSpace(plural)) throw new ArgumentNullException(nameof(plural));

            obj.InternalValidate();

            var response = await this._client.PostAsync(
                $"/apis/{KUBELEANS_GROUP}/{version}/namespaces/{this._namespace}/{plural}",
                new StringContent(JsonConvert.SerializeObject(obj, _jsonSettings),
                _encoding,
                MEDIA_TYPE)).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.Created)
            {
                var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                this._logger?.LogError($"Failure creating Custom Object: {error}");

                return null;
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TObject>(json, _jsonSettings);
        }

        public async Task DeleteCustomObject(string name, string version, string plural)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrWhiteSpace(plural)) throw new ArgumentNullException(nameof(plural));

            var response = await this._client.DeleteAsync($"/apis/{KUBELEANS_GROUP}/{version}/namespaces/{this._namespace}/{plural}/{name}").ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                this._logger?.LogError($"Failure deleting Custom Object: {error}");

                return;
            }
        }

        public async Task<TObject> GetCustomObject<TObject>(string name, string version, string plural) where TObject : CustomObject
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrWhiteSpace(plural)) throw new ArgumentNullException(nameof(plural));

            var response = await this._client.GetAsync($"/apis/{KUBELEANS_GROUP}/{version}/namespaces/{this._namespace}/{plural}/{name}").ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    this._logger?.LogError($"Failure getting Custom Object: {error}");
                }

                return null;
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TObject>(json, _jsonSettings);
        }

        public async Task<IReadOnlyList<TObject>> ListCustomObjects<TObject>(string version, string plural) where TObject : CustomObject
        {
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrWhiteSpace(plural)) throw new ArgumentNullException(nameof(plural));

            var response = await this._client.GetAsync($"/apis/{KUBELEANS_GROUP}/{version}/namespaces/{this._namespace}/{plural}").ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<TObject>();
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                if (response.StatusCode != HttpStatusCode.NotFound)
                {
                    var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    this._logger?.LogError($"Failure listing Custom Object: {error}");
                }

                return new List<TObject>();
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var jsonObject = JObject.Parse(json);
            var customObjectList = jsonObject["items"].ToObject<List<TObject>>();

            return customObjectList;
        }

        public async Task<TObject> UpdateCustomObject<TObject>(string version, string plural, TObject obj) where TObject : CustomObject
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(version)) throw new ArgumentNullException(nameof(version));
            if (string.IsNullOrWhiteSpace(plural)) throw new ArgumentNullException(nameof(plural));

            obj.InternalValidate();

            var response = await this._client.PutAsync($"/apis/{KUBELEANS_GROUP}/{version}/namespaces/{this._namespace}/{plural}/{obj.Metadata.Name}",
                new StringContent(JsonConvert.SerializeObject(obj, _jsonSettings),
                _encoding,
                MEDIA_TYPE)).ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.Conflict ||
                response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Invalid Kubernetes object version");
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                this._logger?.LogError($"Failure updating Custom Object: {error}");

                return null;
            }

            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<TObject>(json, _jsonSettings);
        }

        #endregion

    }
}
