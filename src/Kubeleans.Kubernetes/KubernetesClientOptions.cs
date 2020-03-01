using System.Text.Json;
//using System.Security.Cryptography.X509Certificates;

namespace Kubeleans.Kubernetes
{
    public class KubernetesClientOptions
    {
        public KubernetesClientOptions()
        {
            this.SerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
#if DEBUG
                WriteIndented = true
#else
                WriteIndented = false
#endif
            };
        }

        public string BaseUrl { get; set; }

        public string Namespace { get; set; }

        //public string AccessToken { get; set; }

        //public X509Certificate RootCertificate { get; set; }

        public JsonSerializerOptions SerializerOptions { get; set; }
    }
}
