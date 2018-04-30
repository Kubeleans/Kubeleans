namespace Kubeleans.Kubernetes.Models
{
    /// <summary>
    /// JSON represents any valid JSON value. These types are supported: bool,
    /// int64, float64, string, []interface{}, map[string]interface{} and nil.
    /// </summary>
    public class JSON
    {

        /// <summary>
        /// </summary>
        public byte[] Raw { get; set; }
    }
}
