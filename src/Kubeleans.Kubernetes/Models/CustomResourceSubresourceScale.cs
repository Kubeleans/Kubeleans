namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceSubresourceScale defines how to serve the scale
    /// subresource for CustomResources.
    /// </summary>
    public class CustomResourceSubresourceScale
    {

        /// <summary>
        /// Gets or sets labelSelectorPath defines the JSON path inside of a
        /// CustomResource that corresponds to Scale.Status.Selector. Only JSON
        /// paths without the array notation are allowed. Must be a JSON Path
        /// under .status. Must be set to work with HPA. If there is no value
        /// under the given path in the CustomResource, the status label
        /// selector value in the /scale subresource will default to the empty
        /// string.
        /// </summary>
        public string LabelSelectorPath { get; set; }

        /// <summary>
        /// Gets or sets specReplicasPath defines the JSON path inside of a
        /// CustomResource that corresponds to Scale.Spec.Replicas. Only JSON
        /// paths without the array notation are allowed. Must be a JSON Path
        /// under .spec. If there is no value under the given path in the
        /// CustomResource, the /scale subresource will return an error on GET.
        /// </summary>
        public string SpecReplicasPath { get; set; }

        /// <summary>
        /// Gets or sets statusReplicasPath defines the JSON path inside of a
        /// CustomResource that corresponds to Scale.Status.Replicas. Only JSON
        /// paths without the array notation are allowed. Must be a JSON Path
        /// under .status. If there is no value under the given path in the
        /// CustomResource, the status replica value in the /scale subresource
        /// will default to 0.
        /// </summary>
        public string StatusReplicasPath { get; set; }
    }
}
