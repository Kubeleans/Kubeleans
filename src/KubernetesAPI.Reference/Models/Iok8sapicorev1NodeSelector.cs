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
    /// A node selector represents the union of the results of one or more
    /// label queries over a set of nodes; that is, it represents the OR of the
    /// selectors represented by the node selector terms.
    /// </summary>
    public partial class Iok8sapicorev1NodeSelector
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1NodeSelector class.
        /// </summary>
        public Iok8sapicorev1NodeSelector()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1NodeSelector class.
        /// </summary>
        /// <param name="nodeSelectorTerms">Required. A list of node selector
        /// terms. The terms are ORed.</param>
        public Iok8sapicorev1NodeSelector(IList<Iok8sapicorev1NodeSelectorTerm> nodeSelectorTerms)
        {
            NodeSelectorTerms = nodeSelectorTerms;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets required. A list of node selector terms. The terms are
        /// ORed.
        /// </summary>
        [JsonProperty(PropertyName = "nodeSelectorTerms")]
        public IList<Iok8sapicorev1NodeSelectorTerm> NodeSelectorTerms { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (NodeSelectorTerms == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "NodeSelectorTerms");
            }
            if (NodeSelectorTerms != null)
            {
                foreach (var element in NodeSelectorTerms)
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
