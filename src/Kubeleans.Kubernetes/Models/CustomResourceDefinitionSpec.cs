namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceDefinitionSpec describes how a user wants their resource
    /// to appear
    /// </summary>
    public class CustomResourceDefinitionSpec
    {

        /// <summary>
        /// Gets or sets group is the group this resource belongs in
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets names are the names used to describe this custom
        /// resource
        /// </summary>
        public CustomResourceDefinitionNames Names { get; set; }

        /// <summary>
        /// Gets or sets scope indicates whether this resource is cluster or
        /// namespace scoped.  Default is namespaced
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets subresources describes the subresources for
        /// CustomResources This field is alpha-level and should only be sent
        /// to servers that enable subresources via the
        /// CustomResourceSubresources feature gate.
        /// </summary>
        public CustomResourceSubresources Subresources { get; set; }

        /// <summary>
        /// Gets or sets validation describes the validation methods for
        /// CustomResources
        /// </summary>
        public CustomResourceValidation Validation { get; set; }

        /// <summary>
        /// Gets or sets version is the version this resource belongs in
        /// </summary>
        public string Version { get; set; }
    }
}
