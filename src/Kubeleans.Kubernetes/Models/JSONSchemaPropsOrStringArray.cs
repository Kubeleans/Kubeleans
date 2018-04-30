namespace Kubeleans.Kubernetes.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// JSONSchemaPropsOrStringArray represents a JSONSchemaProps or a string
    /// array.
    /// </summary>
    public class JSONSchemaPropsOrStringArray
    {

        /// <summary>
        /// </summary>
        public IList<string> Property { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaProps Schema { get; set; }
    }
}
