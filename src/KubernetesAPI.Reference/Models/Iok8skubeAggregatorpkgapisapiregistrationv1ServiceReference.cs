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
    /// ServiceReference holds a reference to Service.legacy.k8s.io
    /// </summary>
    public partial class Iok8skubeAggregatorpkgapisapiregistrationv1ServiceReference
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8skubeAggregatorpkgapisapiregistrationv1ServiceReference class.
        /// </summary>
        public Iok8skubeAggregatorpkgapisapiregistrationv1ServiceReference()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8skubeAggregatorpkgapisapiregistrationv1ServiceReference class.
        /// </summary>
        /// <param name="name">Name is the name of the service</param>
        /// <param name="namespaceProperty">Namespace is the namespace of the
        /// service</param>
        public Iok8skubeAggregatorpkgapisapiregistrationv1ServiceReference(string name = default(string), string namespaceProperty = default(string))
        {
            Name = name;
            NamespaceProperty = namespaceProperty;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name is the name of the service
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets namespace is the namespace of the service
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; set; }

    }
}
