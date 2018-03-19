// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Describe a container image
    /// </summary>
    public partial class Iok8sapicorev1ContainerImage
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1ContainerImage
        /// class.
        /// </summary>
        public Iok8sapicorev1ContainerImage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1ContainerImage
        /// class.
        /// </summary>
        /// <param name="names">Names by which this image is known. e.g.
        /// ["k8s.gcr.io/hyperkube:v1.0.7",
        /// "dockerhub.io/google_containers/hyperkube:v1.0.7"]</param>
        /// <param name="sizeBytes">The size of the image in bytes.</param>
        public Iok8sapicorev1ContainerImage(IList<string> names, long? sizeBytes = default(long?))
        {
            Names = names;
            SizeBytes = sizeBytes;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets names by which this image is known. e.g.
        /// ["k8s.gcr.io/hyperkube:v1.0.7",
        /// "dockerhub.io/google_containers/hyperkube:v1.0.7"]
        /// </summary>
        [JsonProperty(PropertyName = "names")]
        public IList<string> Names { get; set; }

        /// <summary>
        /// Gets or sets the size of the image in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "sizeBytes")]
        public long? SizeBytes { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Names == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Names");
            }
        }
    }
}
