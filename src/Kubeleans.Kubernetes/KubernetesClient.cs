using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        private readonly KeyValuePair<string, string> LabelSelector = new KeyValuePair<string, string>("labelSelector", Uri.EscapeDataString("component=kubeleans"));

        private readonly ILogger<KubernetesClient> logger;
        private readonly KubernetesClientOptions options;
        private readonly HttpClient httpClient;
        private readonly JsonSerializer jsonSerializer;

        private static KeyValuePair<string, string>[] immediateDeleteOptions = new[]
        {
                new KeyValuePair<string, string>("gracePeriodSeconds", "0")
        };

        public KubernetesClient(ILogger<KubernetesClient> logger, IOptions<KubernetesClientOptions> options/* TODO with KubernetesClientBuilder, Func<Task<HttpClient>> httpClientFactory = null, HttpClientHandler httpClientHandler = null*/)
        {
            this.logger = logger;
            this.options = options.Value;

            httpClient = new HttpClient();
            jsonSerializer = JsonSerializer.Create(this.options.JsonSerializerSettings);

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

        public async Task<TResult> SendAsync<TResult>(string url, HttpMethod httpMethod, IEnumerable<KeyValuePair<string, string>> queryParameters = default, object payload = default, string contentType = ApplicationJson, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default)
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
                    queryStringBuilder.Append($"{LabelSelector.Key}={LabelSelector.Value}");
                }

                url += $"?{queryStringBuilder.ToString()}";
            }
            else if (addDefaultLabelSelector)
            {
                url += $"?{LabelSelector.Key}={LabelSelector.Value}";
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
                    // StreamContent will dispose it.
                    var memoryStream = new MemoryStream();

                    // JsonTextWriter will dispose it.
                    var streamWriter = new StreamWriter(memoryStream);

                    var jsonTextWriter = new JsonTextWriter(streamWriter);

                    jsonSerializer.Serialize(jsonTextWriter, payload);

                    await streamWriter.FlushAsync();

                    memoryStream.Position = 0;

                    request.Content = new StreamContent(memoryStream);
                    request.Content.Headers.ContentType = jsonMediaType;
                }

                response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw await ApiException.Create(request, request.Method, response, options.JsonSerializerSettings).ConfigureAwait(false);
                }

                cancellationToken.ThrowIfCancellationRequested();

                using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        if (typeof(TResult) == typeof(string))
                        {
                            return (TResult)((object)await streamReader.ReadToEndAsync().ConfigureAwait(false));
                        }
                        else
                        {
                            using (var jsonTextReader = new JsonTextReader(streamReader))
                            {
                                return jsonSerializer.Deserialize<TResult>(jsonTextReader);
                            }
                        }
                    }
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
                    queryStringBuilder.Append($"{LabelSelector.Key}={LabelSelector.Value}");
                }

                queryStringBuilder.Append($"watch=1");

                url += $"?{queryStringBuilder.ToString()}";
            }
            else if (addDefaultLabelSelector)
            {
                url += $"?{LabelSelector.Key}={LabelSelector.Value}&watch=1";
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

                request.Headers.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));

                response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    throw await ApiException.Create(request, request.Method, response, options.JsonSerializerSettings).ConfigureAwait(false);
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

        public async Task WatchObjectChangesAsync<T>(string url, CancellationToken cancellationToken, IKubernetesWatcher<T> watcher) where T : new()
        {
            if (String.IsNullOrWhiteSpace(url))
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

                            while ((line = await streamReader.ReadLineAsync()) != null)
                            {
                                var item = JsonConvert.DeserializeObject<Watch<T>>(line);

                                if (item != null)
                                {
                                    await watcher.Change(item);
                                }
                            }
                        }
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
                            await watcher.Error(ex);
                        }
                    }
                }
            }
        }

        public Task WatchObjectChangesAsync<T>(string url, CancellationToken cancellationToken, Func<Watch<T>, Task> changeHandler, Func<Exception, Task> errorHandler = null) where T : new()
        {
            return WatchObjectChangesAsync(url, cancellationToken, new KubernetesWatcher<T>(changeHandler, errorHandler));
        }

        private void ConfigureHttpClientDefaults()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                httpClient?.Dispose();
            }
        }
    }
}
