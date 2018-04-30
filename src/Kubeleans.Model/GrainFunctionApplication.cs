using Kubeleans.Kubernetes.Models;
using Newtonsoft.Json;

namespace Kubeleans.Model
{
    /// <summary>
    /// Represent a set of functions deployed together to compose an application across the system.
    /// </summary>
    public class GrainFunctionApplication : CustomObject
    {
        [JsonIgnore]
        private const string VERSION = "kubeleans.io/v1";

        [JsonIgnore]
        private const string KIND = "GrainFunctionApplication";

        [JsonIgnore]
        public string Name
        {
            get
            {
                return this.Metadata.Name;
            }
            set
            {
                this.Metadata.Name = value;
            }
        }

        public GrainFunctionApplication()
        {
            this.ApiVersion = VERSION;
            this.Kind = KIND;
        }
    }
}
