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
    /// NetworkPolicyIngressRule describes a particular set of traffic that is
    /// allowed to the pods matched by a NetworkPolicySpec's podSelector. The
    /// traffic must match both ports and from.
    /// </summary>
    public partial class Iok8sapinetworkingv1NetworkPolicyIngressRule
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapinetworkingv1NetworkPolicyIngressRule class.
        /// </summary>
        public Iok8sapinetworkingv1NetworkPolicyIngressRule()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapinetworkingv1NetworkPolicyIngressRule class.
        /// </summary>
        /// <param name="fromProperty">List of sources which should be able to
        /// access the pods selected for this rule. Items in this list are
        /// combined using a logical OR operation. If this field is empty or
        /// missing, this rule matches all sources (traffic not restricted by
        /// source). If this field is present and contains at least on item,
        /// this rule allows traffic only if the traffic matches at least one
        /// item in the from list.</param>
        /// <param name="ports">List of ports which should be made accessible
        /// on the pods selected for this rule. Each item in this list is
        /// combined using a logical OR. If this field is empty or missing,
        /// this rule matches all ports (traffic not restricted by port). If
        /// this field is present and contains at least one item, then this
        /// rule allows traffic only if the traffic matches at least one port
        /// in the list.</param>
        public Iok8sapinetworkingv1NetworkPolicyIngressRule(IList<Iok8sapinetworkingv1NetworkPolicyPeer> fromProperty = default(IList<Iok8sapinetworkingv1NetworkPolicyPeer>), IList<Iok8sapinetworkingv1NetworkPolicyPort> ports = default(IList<Iok8sapinetworkingv1NetworkPolicyPort>))
        {
            FromProperty = fromProperty;
            Ports = ports;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets list of sources which should be able to access the
        /// pods selected for this rule. Items in this list are combined using
        /// a logical OR operation. If this field is empty or missing, this
        /// rule matches all sources (traffic not restricted by source). If
        /// this field is present and contains at least on item, this rule
        /// allows traffic only if the traffic matches at least one item in the
        /// from list.
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public IList<Iok8sapinetworkingv1NetworkPolicyPeer> FromProperty { get; set; }

        /// <summary>
        /// Gets or sets list of ports which should be made accessible on the
        /// pods selected for this rule. Each item in this list is combined
        /// using a logical OR. If this field is empty or missing, this rule
        /// matches all ports (traffic not restricted by port). If this field
        /// is present and contains at least one item, then this rule allows
        /// traffic only if the traffic matches at least one port in the list.
        /// </summary>
        [JsonProperty(PropertyName = "ports")]
        public IList<Iok8sapinetworkingv1NetworkPolicyPort> Ports { get; set; }

    }
}
