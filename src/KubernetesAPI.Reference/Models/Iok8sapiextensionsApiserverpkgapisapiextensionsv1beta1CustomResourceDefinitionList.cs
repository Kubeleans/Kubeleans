// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// CustomResourceDefinitionList is a list of CustomResourceDefinition
    /// objects.
    /// </summary>
    public partial class Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinitionList
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinitionList
        /// class.
        /// </summary>
        public Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinitionList()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinitionList
        /// class.
        /// </summary>
        /// <param name="items">Items individual
        /// CustomResourceDefinitions</param>
        /// <param name="apiVersion">APIVersion defines the versioned schema of
        /// this representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources</param>
        /// <param name="kind">Kind is a string value representing the REST
        /// resource this object represents. Servers may infer this from the
        /// endpoint the client submits requests to. Cannot be updated. In
        /// CamelCase. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds</param>
        public Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinitionList(IList<Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinition> items, string apiVersion = default(string), string kind = default(string), Iok8sapimachinerypkgapismetav1ListMeta metadata = default(Iok8sapimachinerypkgapismetav1ListMeta))
        {
            ApiVersion = apiVersion;
            Items = items;
            Kind = kind;
            Metadata = metadata;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets aPIVersion defines the versioned schema of this
        /// representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources
        /// </summary>
        [JsonProperty(PropertyName = "apiVersion")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets items individual CustomResourceDefinitions
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IList<Iok8sapiextensionsApiserverpkgapisapiextensionsv1beta1CustomResourceDefinition> Items { get; set; }

        /// <summary>
        /// Gets or sets kind is a string value representing the REST resource
        /// this object represents. Servers may infer this from the endpoint
        /// the client submits requests to. Cannot be updated. In CamelCase.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "metadata")]
        public Iok8sapimachinerypkgapismetav1ListMeta Metadata { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Items == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Items");
            }
            if (Items != null)
            {
                foreach (var element in Items)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
