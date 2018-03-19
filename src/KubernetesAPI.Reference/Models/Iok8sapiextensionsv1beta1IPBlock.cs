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
    /// DEPRECATED 1.9 - This group version of IPBlock is deprecated by
    /// networking/v1/IPBlock. IPBlock describes a particular CIDR (Ex.
    /// "192.168.1.1/24") that is allowed to the pods matched by a
    /// NetworkPolicySpec's podSelector. The except entry describes CIDRs that
    /// should not be included within this rule.
    /// </summary>
    public partial class Iok8sapiextensionsv1beta1IPBlock
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapiextensionsv1beta1IPBlock
        /// class.
        /// </summary>
        public Iok8sapiextensionsv1beta1IPBlock()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapiextensionsv1beta1IPBlock
        /// class.
        /// </summary>
        /// <param name="cidr">CIDR is a string representing the IP Block Valid
        /// examples are "192.168.1.1/24"</param>
        /// <param name="except">Except is a slice of CIDRs that should not be
        /// included within an IP Block Valid examples are "192.168.1.1/24"
        /// Except values will be rejected if they are outside the CIDR
        /// range</param>
        public Iok8sapiextensionsv1beta1IPBlock(string cidr, IList<string> except = default(IList<string>))
        {
            Cidr = cidr;
            Except = except;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets CIDR is a string representing the IP Block Valid
        /// examples are "192.168.1.1/24"
        /// </summary>
        [JsonProperty(PropertyName = "cidr")]
        public string Cidr { get; set; }

        /// <summary>
        /// Gets or sets except is a slice of CIDRs that should not be included
        /// within an IP Block Valid examples are "192.168.1.1/24" Except
        /// values will be rejected if they are outside the CIDR range
        /// </summary>
        [JsonProperty(PropertyName = "except")]
        public IList<string> Except { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Cidr == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Cidr");
            }
        }
    }
}
