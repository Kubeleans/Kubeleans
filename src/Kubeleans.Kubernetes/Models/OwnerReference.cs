namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// OwnerReference contains enough information to let you identify an
    /// owning object. Currently, an owning object must be in the same
    /// namespace, so there is no namespace field.
    /// </summary>
    public class OwnerReference
    {
        /// <summary>
        /// Gets or sets API version of the referent.
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets if true, AND if the owner has the "foregroundDeletion"
        /// finalizer, then the owner cannot be deleted from the key-value
        /// store until this reference is removed. Defaults to false. To set
        /// this field, a user needs "delete" permission of the owner,
        /// otherwise 422 (Unprocessable Entity) will be returned.
        /// </summary>
        public bool? BlockOwnerDeletion { get; set; }

        /// <summary>
        /// Gets or sets if true, this reference points to the managing
        /// controller.
        /// </summary>
        public bool? Controller { get; set; }

        /// <summary>
        /// Gets or sets kind of the referent. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets name of the referent. More info:
        /// http://kubernetes.io/docs/user-guide/identifiers#names
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets UID of the referent. More info:
        /// http://kubernetes.io/docs/user-guide/identifiers#uids
        /// </summary>
        public string Uid { get; set; }
    }
}