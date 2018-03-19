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
    /// ResourceAttributes includes the authorization attributes available for
    /// resource requests to the Authorizer interface
    /// </summary>
    public partial class Iok8sapiauthorizationv1ResourceAttributes
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiauthorizationv1ResourceAttributes class.
        /// </summary>
        public Iok8sapiauthorizationv1ResourceAttributes()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapiauthorizationv1ResourceAttributes class.
        /// </summary>
        /// <param name="group">Group is the API Group of the Resource.  "*"
        /// means all.</param>
        /// <param name="name">Name is the name of the resource being requested
        /// for a "get" or deleted for a "delete". "" (empty) means
        /// all.</param>
        /// <param name="namespaceProperty">Namespace is the namespace of the
        /// action being requested.  Currently, there is no distinction between
        /// no namespace and all namespaces "" (empty) is defaulted for
        /// LocalSubjectAccessReviews "" (empty) is empty for cluster-scoped
        /// resources "" (empty) means "all" for namespace scoped resources
        /// from a SubjectAccessReview or SelfSubjectAccessReview</param>
        /// <param name="resource">Resource is one of the existing resource
        /// types.  "*" means all.</param>
        /// <param name="subresource">Subresource is one of the existing
        /// resource types.  "" means none.</param>
        /// <param name="verb">Verb is a kubernetes resource API verb, like:
        /// get, list, watch, create, update, delete, proxy.  "*" means
        /// all.</param>
        /// <param name="version">Version is the API Version of the Resource.
        /// "*" means all.</param>
        public Iok8sapiauthorizationv1ResourceAttributes(string group = default(string), string name = default(string), string namespaceProperty = default(string), string resource = default(string), string subresource = default(string), string verb = default(string), string version = default(string))
        {
            Group = group;
            Name = name;
            NamespaceProperty = namespaceProperty;
            Resource = resource;
            Subresource = subresource;
            Verb = verb;
            Version = version;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets group is the API Group of the Resource.  "*" means
        /// all.
        /// </summary>
        [JsonProperty(PropertyName = "group")]
        public string Group { get; set; }

        /// <summary>
        /// Gets or sets name is the name of the resource being requested for a
        /// "get" or deleted for a "delete". "" (empty) means all.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets namespace is the namespace of the action being
        /// requested.  Currently, there is no distinction between no namespace
        /// and all namespaces "" (empty) is defaulted for
        /// LocalSubjectAccessReviews "" (empty) is empty for cluster-scoped
        /// resources "" (empty) means "all" for namespace scoped resources
        /// from a SubjectAccessReview or SelfSubjectAccessReview
        /// </summary>
        [JsonProperty(PropertyName = "namespace")]
        public string NamespaceProperty { get; set; }

        /// <summary>
        /// Gets or sets resource is one of the existing resource types.  "*"
        /// means all.
        /// </summary>
        [JsonProperty(PropertyName = "resource")]
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets subresource is one of the existing resource types.  ""
        /// means none.
        /// </summary>
        [JsonProperty(PropertyName = "subresource")]
        public string Subresource { get; set; }

        /// <summary>
        /// Gets or sets verb is a kubernetes resource API verb, like: get,
        /// list, watch, create, update, delete, proxy.  "*" means all.
        /// </summary>
        [JsonProperty(PropertyName = "verb")]
        public string Verb { get; set; }

        /// <summary>
        /// Gets or sets version is the API Version of the Resource.  "*" means
        /// all.
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

    }
}
