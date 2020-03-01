using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient : IDisposable
    {
        private const string Group = "kubeleans.io";
        private const string Version1 = "v1";

        private const string ApplicationJson = "application/json";
        private readonly MediaTypeHeaderValue jsonMediaType = new MediaTypeHeaderValue(ApplicationJson);

        private readonly KeyValuePair<string, string> labelSelector = new KeyValuePair<string, string>("labelSelector", Uri.EscapeDataString("component=kubeleans"));

        private readonly ILogger<KubernetesClient> logger;
        private readonly KubernetesClientOptions options;
        private readonly HttpClient httpClient;
        private readonly JsonSerializerOptions serializerOptions;

        private static KeyValuePair<string, string>[] immediateDeleteOptions = new[]
        {
            new KeyValuePair<string, string>("gracePeriodSeconds", "0")
        };

        public KubernetesClient(ILogger<KubernetesClient> logger, IOptions<KubernetesClientOptions> options/* TODO with KubernetesClientBuilder, Func<Task<HttpClient>> httpClientFactory = null, HttpClientHandler httpClientHandler = null*/)
        {
            this.logger = logger;
            this.options = options.Value;

            this.httpClient = new HttpClient();
            this.serializerOptions = this.options.SerializerOptions;

            ConfigureHttpClientDefaults();
        }

        ~KubernetesClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async ValueTask<TResult> SendAsync<TResult>(string url, HttpMethod httpMethod, IEnumerable<KeyValuePair<string, string>> queryParameters = default, object payload = default, string contentType = ApplicationJson, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default)
        {
            if (queryParameters != null)
            {
                var queryStringBuilder = new StringBuilder();

                foreach (var kv in queryParameters)
                {
                    queryStringBuilder.Append($"{kv.Key}={Uri.EscapeDataString(kv.Value)}&");
                }

                if (addDefaultLabelSelector)
                {
                    queryStringBuilder.Append($"{this.labelSelector.Key}={this.labelSelector.Value}");
                }

                url += $"?{queryStringBuilder.ToString()}";
            }
            else if (addDefaultLabelSelector)
            {
                url += $"?{this.labelSelector.Key}={this.labelSelector.Value}";
            }

            var request = new HttpRequestMessage(httpMethod, url);
            var response = default(HttpResponseMessage);
            var disposeResponse = true;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (payload is string stringPayload)
                {
                    if (!string.IsNullOrEmpty(stringPayload))
                    {
                        request.Content = new StringContent(stringPayload);
                        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                    }
                }
                else if (payload != null)
                {
                    var memoryStream = new MemoryStream();

                    await JsonSerializer.SerializeAsync(memoryStream, payload, payload.GetType(), this.serializerOptions);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    request.Content = new StreamContent(memoryStream);
                    request.Content.Headers.ContentType = this.jsonMediaType;
                }

                response = await this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw await ApiException.Create(request, request.Method, response, this.options.SerializerOptions).ConfigureAwait(false);
                }

                cancellationToken.ThrowIfCancellationRequested();

                var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                if (typeof(TResult) == typeof(string))
                {
                    var streamReader = new StreamReader(stream, Encoding.UTF8);
                    return (TResult)((object)await streamReader.ReadToEndAsync().ConfigureAwait(false));
                }
                else
                {
                    return await JsonSerializer.DeserializeAsync<TResult>(stream, this.serializerOptions, cancellationToken).ConfigureAwait(false);
                }
            }
            finally
            {
                request.Dispose();

                if (disposeResponse)
                {
                    response?.Dispose();
                }
            }
        }

        public async Task<Stream> StreamAsync(string url, IEnumerable<KeyValuePair<string, string>> queryParameters = default, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default)
        {
            if (queryParameters != null)
            {
                var queryStringBuilder = new StringBuilder();

                foreach (var kv in queryParameters)
                {
                    queryStringBuilder.Append($"{kv.Key}={Uri.EscapeDataString(kv.Value)}&");
                }

                if (addDefaultLabelSelector)
                {
                    queryStringBuilder.Append($"{this.labelSelector.Key}={this.labelSelector.Value}");
                }

                queryStringBuilder.Append($"watch=1");

                url += $"?{queryStringBuilder.ToString()}";
            }
            else if (addDefaultLabelSelector)
            {
                url += $"?{this.labelSelector.Key}={this.labelSelector.Value}&watch=1";
            }
            else
            {
                url += $"?watch=1";
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = default(HttpResponseMessage);

            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                response = await this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw await ApiException.Create(request, request.Method, response, this.options.SerializerOptions).ConfigureAwait(false);
                }

                cancellationToken.ThrowIfCancellationRequested();

                var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                return stream;
            }
            finally
            {
                request.Dispose();

                // There is no need to dispose the response here, since the only disposable piece is the stream and it is
                // the caller's responsibility to dispose it after done reading/processing.
            }
        }

        public async ValueTask WatchObjectChangesAsync<T>(string url, CancellationToken cancellationToken, IKubernetesWatcher<T> watcher) where T : new()
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            if (watcher == null)
            {
                throw new ArgumentNullException(nameof(watcher));
            }

            using (var stream = await StreamAsync(url))
            {
                using (cancellationToken.Register(() => stream.Dispose()))
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        try
                        {
                            var line = default(string);

                            while ((line = await streamReader.ReadLineAsync().ConfigureAwait(false)) != null)
                            {
                                var ms = new MemoryStream(Encoding.UTF8.GetBytes(line));
                                var item = await JsonSerializer.DeserializeAsync<Watch<T>>(ms, this.serializerOptions);

                                if (item != null)
                                {
                                    await watcher.Change(item).ConfigureAwait(false);
                                }
                            }
                        }
                        catch (IOException) { } // TODO: Check if this happens always or only at tests
                        catch (ObjectDisposedException)
                        {
                            // If cancellation signs the end of reading operation we need to swallow it
                        }
                        catch (OperationCanceledException)
                        {
                            // If cancellation signs the end of reading operation we need to swallow it
                        }
                        catch (Exception ex)
                        {
                            await watcher.Error(ex).ConfigureAwait(false);
                        }
                    }
                }
            }
        }

        public ValueTask WatchObjectChangesAsync<T>(string url, CancellationToken cancellationToken, Func<Watch<T>, Task> changeHandler, Func<Exception, Task> errorHandler = null) where T : new()
        {
            return WatchObjectChangesAsync(url, cancellationToken, new KubernetesWatcher<T>(changeHandler, errorHandler));
        }

        private void ConfigureHttpClientDefaults()
        {
            this.httpClient.BaseAddress = new Uri(this.options.BaseUrl);

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                this.httpClient?.Dispose();
            }
        }
    }
}
