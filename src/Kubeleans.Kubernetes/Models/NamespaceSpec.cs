namespace Kubeleans.Kubernetes.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// NamespaceSpec describes the attributes on a Namespace.
    /// </summary>
    public class NamespaceSpec
    {

        /// <summary>
        /// Gets or sets finalizers is an opaque list of values that must be
        /// empty to permanently remove object from storage. More info:
        /// https://kubernetes.io/docs/tasks/administer-cluster/namespaces/
        /// </summary>
        public List<string> Finalizers { get; set; }
    }
}
