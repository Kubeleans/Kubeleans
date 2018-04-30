namespace Kubeleans.Kubernetes.Models
{

    /// <summary>
    /// CustomResourceValidation is a list of validation methods for
    /// CustomResources.
    /// </summary>
    public class CustomResourceValidation
    {

        /// <summary>
        /// Gets or sets openAPIV3Schema is the OpenAPI v3 schema to be
        /// validated against.
        /// </summary>
        public JSONSchemaProps OpenAPIV3Schema { get; set; }
    }
}
