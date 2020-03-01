using System.Collections.Generic;

namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// Initializers tracks the progress of initialization.
    /// </summary>
    public class Initializers
    {
        /// <summary>
        /// Gets or sets pending is a list of initializers that must execute in
        /// order before this object is visible. When the last pending
        /// initializer is removed, and no failing result is set, the
        /// initializers struct will be set to nil and the object is considered
        /// as initialized and visible to all clients.
        /// </summary>
        public List<Initializer> Pending { get; set; }

        /// <summary>
        /// Gets or sets if result is set with the Failure field, the object
        /// will be persisted to storage and then deleted, ensuring that other
        /// clients can observe the deletion.
        /// </summary>
        public ObjectStatus Result { get; set; }
    }
}