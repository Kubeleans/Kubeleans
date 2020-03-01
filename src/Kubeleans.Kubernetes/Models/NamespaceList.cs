namespace Kubeleans.Kubernetes.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// NamespaceList is a list of Namespaces.
    /// </summary>
    public class NamespaceList
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
        /// Gets or sets items is the list of Namespace objects in the list.
        /// More info:
        /// https://kubernetes.io/docs/concepts/overview/working-with-objects/namespaces/
        /// </summary>
        public List<Namespace> Items { get; set; }

        /// <summary>
        /// Gets or sets kind is a string value representing the REST resource
        /// this object represents. Servers may infer this from the endpoint
        /// the client submits requests to. Cannot be updated. In CamelCase.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets standard list metadata. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public ListMeta Metadata { get; set; }
    }
}
