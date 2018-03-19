// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// UserInfo holds the information about the user needed to implement the
    /// user.Info interface.
    /// </summary>
    public partial class Iok8sapiauthenticationv1UserInfo
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapiauthenticationv1UserInfo
        /// class.
        /// </summary>
        public Iok8sapiauthenticationv1UserInfo()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapiauthenticationv1UserInfo
        /// class.
        /// </summary>
        /// <param name="extra">Any additional information provided by the
        /// authenticator.</param>
        /// <param name="groups">The names of groups this user is a part
        /// of.</param>
        /// <param name="uid">A unique value that identifies this user across
        /// time. If this user is deleted and another user by the same name is
        /// added, they will have different UIDs.</param>
        /// <param name="username">The name that uniquely identifies this user
        /// among all active users.</param>
        public Iok8sapiauthenticationv1UserInfo(IDictionary<string, IList<string>> extra = default(IDictionary<string, IList<string>>), IList<string> groups = default(IList<string>), string uid = default(string), string username = default(string))
        {
            Extra = extra;
            Groups = groups;
            Uid = uid;
            Username = username;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets any additional information provided by the
        /// authenticator.
        /// </summary>
        [JsonProperty(PropertyName = "extra")]
        public IDictionary<string, IList<string>> Extra { get; set; }

        /// <summary>
        /// Gets or sets the names of groups this user is a part of.
        /// </summary>
        [JsonProperty(PropertyName = "groups")]
        public IList<string> Groups { get; set; }

        /// <summary>
        /// Gets or sets a unique value that identifies this user across time.
        /// If this user is deleted and another user by the same name is added,
        /// they will have different UIDs.
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the name that uniquely identifies this user among all
        /// active users.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

    }
}
