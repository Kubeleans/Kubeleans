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
    /// APIService represents a server for a particular GroupVersion. Name must
    /// be "version.group".
    /// </summary>
    public partial class Iok8skubeAggregatorpkgapisapiregistrationv1APIService
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8skubeAggregatorpkgapisapiregistrationv1APIService class.
        /// </summary>
        public Iok8skubeAggregatorpkgapisapiregistrationv1APIService()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8skubeAggregatorpkgapisapiregistrationv1APIService class.
        /// </summary>
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
        /// <param name="spec">Spec contains information for locating and
        /// communicating with a server</param>
        /// <param name="status">Status contains derived information about an
        /// API server</param>
        public Iok8skubeAggregatorpkgapisapiregistrationv1APIService(string apiVersion = default(string), string kind = default(string), Iok8sapimachinerypkgapismetav1ObjectMeta metadata = default(Iok8sapimachinerypkgapismetav1ObjectMeta), Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceSpec spec = default(Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceSpec), Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceStatus status = default(Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceStatus))
        {
            ApiVersion = apiVersion;
            Kind = kind;
            Metadata = metadata;
            Spec = spec;
            Status = status;
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
        public Iok8sapimachinerypkgapismetav1ObjectMeta Metadata { get; set; }

        /// <summary>
        /// Gets or sets spec contains information for locating and
        /// communicating with a server
        /// </summary>
        [JsonProperty(PropertyName = "spec")]
        public Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceSpec Spec { get; set; }

        /// <summary>
        /// Gets or sets status contains derived information about an API
        /// server
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public Iok8skubeAggregatorpkgapisapiregistrationv1APIServiceStatus Status { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Metadata != null)
            {
                Metadata.Validate();
            }
            if (Spec != null)
            {
                Spec.Validate();
            }
        }
    }
}
