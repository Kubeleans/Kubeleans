// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// SecretEnvSource selects a Secret to populate the environment variables
    /// with.
    ///
    /// The contents of the target Secret's Data field will represent the
    /// key-value pairs as environment variables.
    /// </summary>
    public partial class Iok8sapicorev1SecretEnvSource
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1SecretEnvSource
        /// class.
        /// </summary>
        public Iok8sapicorev1SecretEnvSource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1SecretEnvSource
        /// class.
        /// </summary>
        /// <param name="name">Name of the referent. More info:
        /// https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#names</param>
        /// <param name="optional">Specify whether the Secret must be
        /// defined</param>
        public Iok8sapicorev1SecretEnvSource(string name = default(string), bool? optional = default(bool?))
        {
            Name = name;
            Optional = optional;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of the referent. More info:
        /// https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#names
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets specify whether the Secret must be defined
        /// </summary>
        [JsonProperty(PropertyName = "optional")]
        public bool? Optional { get; set; }

    }
}
