using Microsoft.Extensions.Logging;
using System;

namespace Kubeleans.Kubernetes.Tests
{
    public class KubernetesClientFixture : IDisposable
    {
        private readonly Random random;

        public KubernetesClientFixture()
        {
            this.random = new Random();

            var @namespace = GetTemporaryObjectName("ns");

            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<KubernetesClient>();

            this.Options = new KubernetesClientOptions
            {
                //BaseUrl = "http://ipv4.fiddler:8001",
                BaseUrl = "http://localhost:8001",
                Namespace = @namespace
            };

            var options = Microsoft.Extensions.Options.Options.Create(this.Options);

            this.ApiClient = new KubernetesClient(logger, options);
        }

        public void Dispose()
        {
        }

        public string GetTemporaryObjectName(string objectType, bool useDotAsSeparator = false) => $"kubeleans-{objectType.ToLowerInvariant()}{(useDotAsSeparator ? "." : "-")}{this.random.Next()}";

        public string GetKind(string objectName)
        {
            var parts = objectName.Split('-');

            return parts[0].Substring(0, 1).ToUpperInvariant() + parts[0].Substring(1).ToLowerInvariant() +
                parts[1].Substring(0, 1).ToUpperInvariant() + parts[1].Substring(1).ToLowerInvariant() +
                parts[2];
        }

        public string GetShortName(string objectName)
        {
            var parts = objectName.Split('-');

            return parts[0].Substring(0, 1).ToLowerInvariant() +
                parts[1].Substring(0, 1).ToLowerInvariant() +
                parts[2];
        }

        public KubernetesClient ApiClient { get; }

        public string Namespace => this.Options.Namespace;

        public KubernetesClientOptions Options { get; }
    }
}
