using Kubeleans.Kubernetes.Models;
using Newtonsoft.Json;
using System;

namespace Kubeleans.Model
{
    /// <summary>
    /// Represent a Grain Function definition in the system.
    /// The GrainFunction is contained inside a <see cref="GrainFunctionApplication"/>
    /// </summary>
    public class GrainFunction : CustomObject
    {
        [JsonIgnore]
        private const string VERSION = "kubeleans.io/v1";

        [JsonIgnore]
        private const string KIND = "GrainFunction";

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

        public string ApplicationName { get; set; }
        public FunctionActivationMode ActivationMode { get; set; }
        public FunctionRuntime Runtime { get; set; }

        public GrainFunction()
        {
            this.ApiVersion = VERSION;
            this.Kind = KIND;
        }

        //protected override void Validate()
        //{
        //    if (string.IsNullOrWhiteSpace(this.ApplicationName)) throw new ArgumentNullException(nameof(this.ApplicationName));
        //}
    }
}
