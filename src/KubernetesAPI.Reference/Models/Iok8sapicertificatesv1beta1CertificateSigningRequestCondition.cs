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

    public partial class Iok8sapicertificatesv1beta1CertificateSigningRequestCondition
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicertificatesv1beta1CertificateSigningRequestCondition
        /// class.
        /// </summary>
        public Iok8sapicertificatesv1beta1CertificateSigningRequestCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicertificatesv1beta1CertificateSigningRequestCondition
        /// class.
        /// </summary>
        /// <param name="type">request approval state, currently Approved or
        /// Denied.</param>
        /// <param name="lastUpdateTime">timestamp for the last update to this
        /// condition</param>
        /// <param name="message">human readable message with details about the
        /// request state</param>
        /// <param name="reason">brief reason for the request state</param>
        public Iok8sapicertificatesv1beta1CertificateSigningRequestCondition(string type, System.DateTimeOffset? lastUpdateTime = default(System.DateTimeOffset?), string message = default(string), string reason = default(string))
        {
            LastUpdateTime = lastUpdateTime;
            Message = message;
            Reason = reason;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets timestamp for the last update to this condition
        /// </summary>
        [JsonProperty(PropertyName = "lastUpdateTime")]
        public System.DateTimeOffset? LastUpdateTime { get; set; }

        /// <summary>
        /// Gets or sets human readable message with details about the request
        /// state
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets brief reason for the request state
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets request approval state, currently Approved or Denied.
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
            if (Type == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Type");
            }
        }
    }
}
