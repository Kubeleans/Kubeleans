namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// Status is a return value for calls that don't return other objects.
    /// </summary>
    public class ObjectStatus
    {
        public const string Active = "Active";
        public const string Terminating = "Terminating";

        /// <summary>
        /// Gets or sets aPIVersion defines the versioned schema of this
        /// representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets suggested HTTP return code for this status, 0 if not
        /// set.
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// Gets or sets extended data associated with the reason.  Each reason
        /// may define its own extended details. This field is optional and the
        /// data returned is not guaranteed to conform to any schema except
        /// that defined by the reason type.
        /// </summary>
        public StatusDetails Details { get; set; }

        /// <summary>
        /// Gets or sets kind is a string value representing the REST resource
        /// this object represents. Servers may infer this from the endpoint
        /// the client submits requests to. Cannot be updated. In CamelCase.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description of the status of this
        /// operation.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets standard list metadata. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        public ListMeta Metadata { get; set; }

        /// <summary>
        /// Gets or sets a machine-readable description of why this operation
        /// is in the "Failure" status. If this value is empty there is no
        /// information available. A Reason clarifies an HTTP status code but
        /// does not override it.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets status of the operation. One of: "Success" or
        /// "Failure". More info:
        /// https://git.k8s.io/community/contributors/devel/a   pi-conventions.md#spec-and-status
        /// </summary>
        public string Status { get; set; }
    }
}