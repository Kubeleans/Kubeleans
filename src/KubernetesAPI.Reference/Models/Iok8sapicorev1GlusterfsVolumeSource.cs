// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Represents a Glusterfs mount that lasts the lifetime of a pod.
    /// Glusterfs volumes do not support ownership management or SELinux
    /// relabeling.
    /// </summary>
    public partial class Iok8sapicorev1GlusterfsVolumeSource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1GlusterfsVolumeSource class.
        /// </summary>
        public Iok8sapicorev1GlusterfsVolumeSource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1GlusterfsVolumeSource class.
        /// </summary>
        /// <param name="endpoints">EndpointsName is the endpoint name that
        /// details Glusterfs topology. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod</param>
        /// <param name="path">Path is the Glusterfs volume path. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod</param>
        /// <param name="readOnlyProperty">ReadOnly here will force the
        /// Glusterfs volume to be mounted with read-only permissions. Defaults
        /// to false. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod</param>
        public Iok8sapicorev1GlusterfsVolumeSource(string endpoints, string path, bool? readOnlyProperty = default(bool?))
        {
            Endpoints = endpoints;
            Path = path;
            ReadOnlyProperty = readOnlyProperty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets endpointsName is the endpoint name that details
        /// Glusterfs topology. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod
        /// </summary>
        [JsonProperty(PropertyName = "endpoints")]
        public string Endpoints { get; set; }

        /// <summary>
        /// Gets or sets path is the Glusterfs volume path. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets readOnly here will force the Glusterfs volume to be
        /// mounted with read-only permissions. Defaults to false. More info:
        /// https://releases.k8s.io/HEAD/examples/volumes/glusterfs/README.md#create-a-pod
        /// </summary>
        [JsonProperty(PropertyName = "readOnly")]
        public bool? ReadOnlyProperty { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Endpoints == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Endpoints");
            }
            if (Path == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Path");
            }
        }
    }
}
