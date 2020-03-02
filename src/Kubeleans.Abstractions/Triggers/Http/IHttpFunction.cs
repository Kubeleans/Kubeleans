using System.Net.Http;
using System.Threading.Tasks;

namespace Kubeleans.Abstractions.Triggers.Http
{
    public interface IHttpFunction : IKubeleansFunction
    {
        ValueTask<HttpResponseMessage> Execute(HttpRequestMessage request);
    }
}