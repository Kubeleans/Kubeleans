namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceSubresources defines the status and scale subresources
    /// for CustomResources.
    /// </summary>
    public class CustomResourceSubresources
    {

        /// <summary>
        /// Gets or sets scale denotes the scale subresource for
        /// CustomResources
        /// </summary>
        public CustomResourceSubresourceScale Scale { get; set; }

        /// <summary>
        /// Gets or sets status denotes the status subresource for
        /// CustomResources
        /// </summary>
        public object Status { get; set; }
    }
}
