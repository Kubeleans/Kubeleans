namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// NamespaceStatus is information about the current status of a Namespace.
    /// </summary>
    public class NamespaceStatus
    {

        /// <summary>
        /// Gets or sets phase is the current lifecycle phase of the namespace.
        /// More info:
        /// https://kubernetes.io/docs/tasks/administer-cluster/namespaces/
        /// </summary>
        public string Phase { get; set; }
    }
}
