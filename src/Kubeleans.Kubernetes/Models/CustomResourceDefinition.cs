namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceDefinition represents a resource that should be exposed
    /// on the API server.  Its name MUST be in the format
    /// &lt;.spec.name&gt;.&lt;.spec.group&gt;.
    /// </summary>
    public class CustomResourceDefinition
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
        /// </summary>
        public ObjectMeta Metadata { get; set; }

        /// <summary>
        /// Gets or sets spec describes how the user wants the resources to
        /// appear
        /// </summary>
        public CustomResourceDefinitionSpec Spec { get; set; }

        /// <summary>
        /// Gets or sets status indicates the actual state of the
        /// CustomResourceDefinition
        /// </summary>
        public CustomResourceDefinitionStatus Status { get; set; }
    }
}
