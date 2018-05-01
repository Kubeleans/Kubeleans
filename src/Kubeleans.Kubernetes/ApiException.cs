using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    // Based on https://github.com/paulcbetts/refit/blob/master/Refit/ApiException.cs
    public class ApiException : Exception
    {
        protected readonly JsonSerializerSettings jsonSerializerSettings;

        public ApiException(HttpRequestMessage request, HttpMethod httpMethod, HttpStatusCode statusCode, string reasonPhrase, HttpResponseHeaders headers, JsonSerializerSettings jsonSerializerSettings)
            : base(CreateMessage(statusCode, reasonPhrase))
        {
            this.Request = request;
            this.Method = httpMethod;
            this.StatusCode = statusCode;
            this.ReasonPhrase = reasonPhrase;
            this.Headers = headers;

            this.jsonSerializerSettings = jsonSerializerSettings;
        }
        public T GetContentAs<T>() => this.HasContent ? JsonConvert.DeserializeObject<T>(this.Content, this.jsonSerializerSettings) : default;

        public HttpContentHeaders ContentHeaders { get; private set; }

        public string Content { get; private set; }

        public bool HasContent => !string.IsNullOrWhiteSpace(this.Content);

        public HttpResponseHeaders Headers { get; }

        public HttpMethod Method { get; }

        public string ReasonPhrase { get; }

        public HttpRequestMessage Request { get; }

        public HttpStatusCode StatusCode { get; }

        public Uri Uri => this.Request.RequestUri;

        internal static async Task<KubernetesApiException> Create(HttpRequestMessage request, HttpMethod httpMethod, HttpResponseMessage response, JsonSerializerSettings jsonSerializerSettings)
        {
            var exception = new KubernetesApiException(request, httpMethod, response.StatusCode, response.ReasonPhrase, response.Headers, jsonSerializerSettings);

            if (response.Content == null)
            {
                return exception;
            }

            try
            {
                exception.ContentHeaders = response.Content.Headers;
                exception.Content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                response.Content.Dispose();
            }
            catch
            {
                // NB: We're already handling an exception at this point, 
                // so we want to make sure we don't throw another one 
                // that hides the real error.
            }

            return exception;
        }

        static string CreateMessage(HttpStatusCode statusCode, string reasonPhrase) =>
            $"Response status code does not indicate success: {(int)statusCode} ({reasonPhrase}).";
    }
}