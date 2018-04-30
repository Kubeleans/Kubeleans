namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// Namespace provides a scope for Names. Use of multiple namespaces is
    /// optional.
    /// </summary>
    public class Namespace
    {

        /// <summary>
        /// Gets or sets APIVersion defines the versioned schema of this
        /// representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets kind is a string value representing the REST resource
        /// this object represents. Servers may infer this from the endpoint
        /// the client submits requests to. Cannot be updated. In CamelCase.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets standard object's metadata. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#metadata
        /// </summary>
        public ObjectMeta Metadata { get; set; }

        /// <summary>
        /// Gets or sets spec defines the behavior of the Namespace. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status
        /// </summary>
        public NamespaceSpec Spec { get; set; }

        /// <summary>
        /// Gets or sets status describes the current status of a Namespace.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#spec-and-status
        /// </summary>
        public NamespaceStatus Status { get; set; }
    }
}
