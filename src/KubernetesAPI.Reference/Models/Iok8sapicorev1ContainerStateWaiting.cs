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
    /// ContainerStateWaiting is a waiting state of a container.
    /// </summary>
    public partial class Iok8sapicorev1ContainerStateWaiting
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1ContainerStateWaiting class.
        /// </summary>
        public Iok8sapicorev1ContainerStateWaiting()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1ContainerStateWaiting class.
        /// </summary>
        /// <param name="message">Message regarding why the container is not
        /// yet running.</param>
        /// <param name="reason">(brief) reason the container is not yet
        /// running.</param>
        public Iok8sapicorev1ContainerStateWaiting(string message = default(string), string reason = default(string))
        {
            Message = message;
            Reason = reason;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets message regarding why the container is not yet
        /// running.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets (brief) reason the container is not yet running.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

    }
}
