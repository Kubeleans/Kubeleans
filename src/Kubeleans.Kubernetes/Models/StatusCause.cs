namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// StatusCause provides more information about an api.Status failure,
    /// including cases when multiple errors are encountered.
    /// </summary>
    public class StatusCause
    {
        /// <summary>
        /// Gets or sets the field of the resource that has caused this error,
        /// as named by its JSON serialization. May include dot and postfix
        /// notation for nested attributes. Arrays are zero-indexed.  Fields
        /// may appear more than once in an array of causes due to fields
        /// having multiple errors. Optional.
        ///
        /// Examples:
        /// "name" - the field "name" on the current resource
        /// "items[0].name" - the field "name" on the first array entry in
        /// "items"
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets a human-readable description of the cause of the
        /// error.  This field may be presented as-is to a reader.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets a machine-readable description of the cause of the
        /// error. If this value is empty there is no information available.
        /// </summary>
        public string Reason { get; set; }
    }
}