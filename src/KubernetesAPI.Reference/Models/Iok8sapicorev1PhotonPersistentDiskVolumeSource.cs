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
    /// Represents a Photon Controller persistent disk resource.
    /// </summary>
    public partial class Iok8sapicorev1PhotonPersistentDiskVolumeSource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1PhotonPersistentDiskVolumeSource class.
        /// </summary>
        public Iok8sapicorev1PhotonPersistentDiskVolumeSource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapicorev1PhotonPersistentDiskVolumeSource class.
        /// </summary>
        /// <param name="pdID">ID that identifies Photon Controller persistent
        /// disk</param>
        /// <param name="fsType">Filesystem type to mount. Must be a filesystem
        /// type supported by the host operating system. Ex. "ext4", "xfs",
        /// "ntfs". Implicitly inferred to be "ext4" if unspecified.</param>
        public Iok8sapicorev1PhotonPersistentDiskVolumeSource(string pdID, string fsType = default(string))
        {
            FsType = fsType;
            PdID = pdID;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets filesystem type to mount. Must be a filesystem type
        /// supported by the host operating system. Ex. "ext4", "xfs", "ntfs".
        /// Implicitly inferred to be "ext4" if unspecified.
        /// </summary>
        [JsonProperty(PropertyName = "fsType")]
        public string FsType { get; set; }

        /// <summary>
        /// Gets or sets ID that identifies Photon Controller persistent disk
        /// </summary>
        [JsonProperty(PropertyName = "pdID")]
        public string PdID { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PdID == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PdID");
            }
        }
    }
}
