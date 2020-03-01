using Kubeleans.Kubernetes.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public class KubernetesApiException : ApiException
    {
        public KubernetesApiException(HttpRequestMessage request, HttpMethod httpMethod, HttpStatusCode statusCode, string reasonPhrase, HttpResponseHeaders headers, JsonSerializerOptions serializerOptions)
            : base(request, httpMethod, statusCode, reasonPhrase, headers, serializerOptions)
        {
        }

        public ValueTask<ObjectStatus> Status => GetContentAs<ObjectStatus>();
    }
}