namespace Kubeleans.Kubernetes.Models
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// JSONSchemaPropsOrArray represents a value that can either be a
    /// JSONSchemaProps or an array of JSONSchemaProps. Mainly here for
    /// serialization purposes.
    /// </summary>
    public class JSONSchemaPropsOrArray
    {

        /// <summary>
        /// </summary>
        public List<JSONSchemaProps> JSONSchemas { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaProps Schema { get; set; }
    }
}
