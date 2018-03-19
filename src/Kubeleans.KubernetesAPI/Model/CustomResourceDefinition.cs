using Newtonsoft.Json;

namespace Kubeleans.KubernetesAPI.Model
{
    internal class CustomResourceDefinition : CustomObject
    {
        [JsonIgnore]
        private const string KIND = "CustomResourceDefinition";

        [JsonIgnore]
        private const string API_VERSION = "apiextensions.k8s.io/v1beta1";

        public CustomResourceDefinitionSpec Spec { get; set; }

        public CustomResourceDefinition()
        {
            this.Kind = KIND;
            this.ApiVersion = API_VERSION;
        }
    }
}
