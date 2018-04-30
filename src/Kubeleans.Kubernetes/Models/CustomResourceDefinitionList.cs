namespace Kubeleans.Kubernetes.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// CustomResourceDefinitionList is a list of CustomResourceDefinition
    /// objects.
    /// </summary>
    public class CustomResourceDefinitionList
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
        /// Gets or sets items individual CustomResourceDefinitions
        /// </summary>
        public IList<CustomResourceDefinition> Items { get; set; }

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
        public ListMeta Metadata { get; set; }
    }
}
