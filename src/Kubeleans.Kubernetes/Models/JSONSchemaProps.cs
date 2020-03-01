namespace Kubeleans.Kubernetes.Models
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// JSONSchemaProps is a JSON-Schema following Specification Draft 4
    /// (http://json-schema.org/).
    /// </summary>
    public class JSONSchemaProps
    {

        /// <summary>
        /// </summary>
        public string RefProperty { get; set; }

        /// <summary>
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaPropsOrBool AdditionalItems { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaPropsOrBool AdditionalProperties { get; set; }

        /// <summary>
        /// </summary>
        public List<JSONSchemaProps> AllOf { get; set; }

        /// <summary>
        /// </summary>
        public List<JSONSchemaProps> AnyOf { get; set; }

        /// <summary>
        /// </summary>
        public JSON DefaultProperty { get; set; }

        /// <summary>
        /// </summary>
        public Dictionary<string, JSONSchemaProps> Definitions { get; set; }

        /// <summary>
        /// </summary>
        public Dictionary<string, JSONSchemaPropsOrStringArray> Dependencies { get; set; }

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public List<JSON> EnumProperty { get; set; }

        /// <summary>
        /// </summary>
        public JSON Example { get; set; }

        /// <summary>
        /// </summary>
        public bool? ExclusiveMaximum { get; set; }

        /// <summary>
        /// </summary>
        public bool? ExclusiveMinimum { get; set; }

        /// <summary>
        /// </summary>
        public ExternalDocumentation ExternalDocs { get; set; }

        /// <summary>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaPropsOrArray Items { get; set; }

        /// <summary>
        /// </summary>
        public long? MaxItems { get; set; }

        /// <summary>
        /// </summary>
        public long? MaxLength { get; set; }

        /// <summary>
        /// </summary>
        public long? MaxProperties { get; set; }

        /// <summary>
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// </summary>
        public long? MinItems { get; set; }

        /// <summary>
        /// </summary>
        public long? MinLength { get; set; }

        /// <summary>
        /// </summary>
        public long? MinProperties { get; set; }

        /// <summary>
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// </summary>
        public double? MultipleOf { get; set; }

        /// <summary>
        /// </summary>
        public JSONSchemaProps Not { get; set; }

        /// <summary>
        /// </summary>
        public List<JSONSchemaProps> OneOf { get; set; }

        /// <summary>
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// </summary>
        public Dictionary<string, JSONSchemaProps> PatternProperties { get; set; }

        /// <summary>
        /// </summary>
        public Dictionary<string, JSONSchemaProps> Properties { get; set; }

        /// <summary>
        /// </summary>
        public List<string> Required { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        public bool? UniqueItems { get; set; }
    }
}
