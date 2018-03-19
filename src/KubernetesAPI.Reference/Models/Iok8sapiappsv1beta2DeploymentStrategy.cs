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
    /// DeploymentStrategy describes how to replace existing pods with new
    /// ones.
    /// </summary>
    public partial class Iok8sapiappsv1beta2DeploymentStrategy
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiappsv1beta2DeploymentStrategy class.
        /// </summary>
        public Iok8sapiappsv1beta2DeploymentStrategy()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiappsv1beta2DeploymentStrategy class.
        /// </summary>
        /// <param name="rollingUpdate">Rolling update config params. Present
        /// only if DeploymentStrategyType = RollingUpdate.</param>
        /// <param name="type">Type of deployment. Can be "Recreate" or
        /// "RollingUpdate". Default is RollingUpdate.</param>
        public Iok8sapiappsv1beta2DeploymentStrategy(Iok8sapiappsv1beta2RollingUpdateDeployment rollingUpdate = default(Iok8sapiappsv1beta2RollingUpdateDeployment), string type = default(string))
        {
            RollingUpdate = rollingUpdate;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets rolling update config params. Present only if
        /// DeploymentStrategyType = RollingUpdate.
        /// </summary>
        [JsonProperty(PropertyName = "rollingUpdate")]
        public Iok8sapiappsv1beta2RollingUpdateDeployment RollingUpdate { get; set; }

        /// <summary>
        /// Gets or sets type of deployment. Can be "Recreate" or
        /// "RollingUpdate". Default is RollingUpdate.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
