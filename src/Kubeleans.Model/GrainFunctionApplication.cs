using System.Text.Json.Serialization;
using Kubeleans.Kubernetes.Models;

namespace Kubeleans.Model
{
    /// <summary>
    /// Represent a set of functions deployed together to compose an application across the system.
    /// </summary>
    public class GrainFunctionApplication : CustomObject
    {
        private const string VERSION = "kubeleans.io/v1";
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
