using Newtonsoft.Json;

namespace Kubeleans.KubernetesAPI.Model
{
    internal class CustomResourceDefinitionSpec
    {
        [JsonIgnore]
        private const string NAMESPACED = "Namespaced";

        public string Group { get; set; }

        public CustomResourceDefinitionNames Names { get; set; }

        public string Scope { get; set; }

        public string Version { get; set; }

        public CustomResourceDefinitionSpec()
        {
            this.Scope = NAMESPACED;
        }
    }
}
