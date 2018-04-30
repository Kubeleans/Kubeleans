namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// Initializer is information about an initializer that has not yet
    /// completed.
    /// </summary>
    public class Initializer
    {
        /// <summary>
        /// Gets or sets name of the process that is responsible for
        /// initializing this object.
        /// </summary>
        public string Name { get; set; }
    }
}