namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceDefinitionCondition contains details for the current
    /// condition of this pod.
    /// </summary>
    public class CustomResourceDefinitionCondition
    {

        /// <summary>
        /// Gets or sets last time the condition transitioned from one status
        /// to another.
        /// </summary>
        public System.DateTimeOffset? LastTransitionTime { get; set; }

        /// <summary>
        /// Gets or sets human-readable message indicating details about last
        /// transition.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets unique, one-word, CamelCase reason for the condition's
        /// last transition.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets status is the status of the condition. Can be True,
        /// False, Unknown.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets type is the type of the condition.
        /// </summary>
        public string Type { get; set; }
    }
}
