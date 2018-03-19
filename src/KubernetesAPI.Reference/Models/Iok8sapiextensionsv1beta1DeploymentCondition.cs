// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// DeploymentCondition describes the state of a deployment at a certain
    /// point.
    /// </summary>
    public partial class Iok8sapiextensionsv1beta1DeploymentCondition
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsv1beta1DeploymentCondition class.
        /// </summary>
        public Iok8sapiextensionsv1beta1DeploymentCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsv1beta1DeploymentCondition class.
        /// </summary>
        /// <param name="status">Status of the condition, one of True, False,
        /// Unknown.</param>
        /// <param name="type">Type of deployment condition.</param>
        /// <param name="lastTransitionTime">Last time the condition
        /// transitioned from one status to another.</param>
        /// <param name="lastUpdateTime">The last time this condition was
        /// updated.</param>
        /// <param name="message">A human readable message indicating details
        /// about the transition.</param>
        /// <param name="reason">The reason for the condition's last
        /// transition.</param>
        public Iok8sapiextensionsv1beta1DeploymentCondition(string status, string type, System.DateTimeOffset? lastTransitionTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdateTime = default(System.DateTimeOffset?), string message = default(string), string reason = default(string))
        {
            LastTransitionTime = lastTransitionTime;
            LastUpdateTime = lastUpdateTime;
            Message = message;
            Reason = reason;
            Status = status;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets last time the condition transitioned from one status
        /// to another.
        /// </summary>
        [JsonProperty(PropertyName = "lastTransitionTime")]
        public System.DateTimeOffset? LastTransitionTime { get; set; }

        /// <summary>
        /// Gets or sets the last time this condition was updated.
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdateTime")]
        public System.DateTimeOffset? LastUpdateTime { get; set; }

        /// <summary>
        /// Gets or sets a human readable message indicating details about the
        /// transition.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the reason for the condition's last transition.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets status of the condition, one of True, False, Unknown.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets type of deployment condition.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Status == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Status");
            }
            if (Type == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Type");
            }
        }
    }
}
