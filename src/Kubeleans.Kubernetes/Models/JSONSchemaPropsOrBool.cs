namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// JSONSchemaPropsOrBool represents JSONSchemaProps or a boolean value.
    /// Defaults to true for the boolean property.
    /// </summary>
    public class JSONSchemaPropsOrBool
    {

        /// <summary>
        /// </summary>
        public bool Allows { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaProps Schema { get; set; }
    }
}
