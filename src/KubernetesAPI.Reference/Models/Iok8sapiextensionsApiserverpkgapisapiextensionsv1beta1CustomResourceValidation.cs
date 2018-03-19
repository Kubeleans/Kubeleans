// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// CustomResourceValidation is a list of validation methods for
    /// CustomResources.
    /// </summary>
    public partial class Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceValidation
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceValidation
        /// class.
        /// </summary>
        public Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceValidation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceValidation
        /// class.
        /// </summary>
        /// <param name="openAPIV3Schema">OpenAPIV3Schema is the OpenAPI v3
        /// schema to be validated against.</param>
        public Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceValidation(Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1JSONSchemaProps openAPIV3Schema = default(Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1JSONSchemaProps))
        {
            OpenAPIV3Schema = openAPIV3Schema;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets openAPIV3Schema is the OpenAPI v3 schema to be
        /// validated against.
        /// </summary>
        [JsonProperty(PropertyName = "openAPIV3Schema")]
        public Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1JSONSchemaProps OpenAPIV3Schema { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (OpenAPIV3Schema != null)
            {
                OpenAPIV3Schema.Validate();
            }
        }
    }
}
