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
    /// DEPRECATED.
    /// </summary>
    public partial class Iok8sapiappsv1beta1RollbackConfig
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapiappsv1beta1RollbackConfig
        /// class.
        /// </summary>
        public Iok8sapiappsv1beta1RollbackConfig()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapiappsv1beta1RollbackConfig
        /// class.
        /// </summary>
        /// <param name="revision">The revision to rollback to. If set to 0,
        /// rollback to the last revision.</param>
        public Iok8sapiappsv1beta1RollbackConfig(long? revision = default(long?))
        {
            Revision = revision;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the revision to rollback to. If set to 0, rollback to
        /// the last revision.
        /// </summary>
        [JsonProperty(PropertyName = "revision")]
        public long? Revision { get; set; }

    }
}
