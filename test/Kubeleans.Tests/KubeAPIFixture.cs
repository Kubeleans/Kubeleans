using Kubeleans.KubernetesAPI;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Kubeleans.Tests
{
    public class KubeAPIFixture
    {
        internal Kubernetes Client { get; set; } = new Kubernetes(
            Options.Create(new KubernetesOptions { APIEndpoint = "http://localhost:8001" }), NullLoggerFactory.Instance);
    }
}
