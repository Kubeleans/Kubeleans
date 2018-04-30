using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Globalization;
//using System.Security.Cryptography.X509Certificates;

namespace Kubeleans.Kubernetes
{
    public class KubernetesClientOptions
    {
        public KubernetesClientOptions()
        {
            JsonSerializerSettings = new JsonSerializerSettings
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
        }

        public string BaseUrl { get; set; }

        public string Namespace { get; set; }

        //public string AccessToken { get; set; }

        //public X509Certificate RootCertificate { get; set; }

        public JsonSerializerSettings JsonSerializerSettings { get; set; }
    }
}
