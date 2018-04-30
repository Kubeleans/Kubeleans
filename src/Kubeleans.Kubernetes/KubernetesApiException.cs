using Kubeleans.Kubernetes.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Kubeleans.Kubernetes
{
    public class KubernetesApiException : ApiException
    {
        public KubernetesApiException(HttpRequestMessage request, HttpMethod httpMethod, HttpStatusCode statusCode, string reasonPhrase, HttpResponseHeaders headers, JsonSerializerSettings jsonSerializerSettings)
            : base(request, httpMethod, statusCode, reasonPhrase, headers, jsonSerializerSettings)
        {
        }

        public ObjectStatus Status => GetContentAs<ObjectStatus>();
    }
}