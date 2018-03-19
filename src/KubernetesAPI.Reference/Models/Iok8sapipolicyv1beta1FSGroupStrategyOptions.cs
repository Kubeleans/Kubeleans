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
    /// FSGroupStrategyOptions defines the strategy type and options used to
    /// create the strategy.
    /// </summary>
    public partial class Iok8sapipolicyv1beta1FSGroupStrategyOptions
    {
        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapipolicyv1beta1FSGroupStrategyOptions class.
        /// </summary>
        public Iok8sapipolicyv1beta1FSGroupStrategyOptions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// Iok8sapipolicyv1beta1FSGroupStrategyOptions class.
        /// </summary>
        /// <param name="ranges">Ranges are the allowed ranges of fs groups.
        /// If you would like to force a single fs group then supply a single
        /// range with the same start and end.</param>
        /// <param name="rule">Rule is the strategy that will dictate what
        /// FSGroup is used in the SecurityContext.</param>
        public Iok8sapipolicyv1beta1FSGroupStrategyOptions(IList<Iok8sapipolicyv1beta1IDRange> ranges = default(IList<Iok8sapipolicyv1beta1IDRange>), string rule = default(string))
        {
            Ranges = ranges;
            Rule = rule;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets ranges are the allowed ranges of fs groups.  If you
        /// would like to force a single fs group then supply a single range
        /// with the same start and end.
        /// </summary>
        [JsonProperty(PropertyName = "ranges")]
        public IList<Iok8sapipolicyv1beta1IDRange> Ranges { get; set; }

        /// <summary>
        /// Gets or sets rule is the strategy that will dictate what FSGroup is
        /// used in the SecurityContext.
        /// </summary>
        [JsonProperty(PropertyName = "rule")]
        public string Rule { get; set; }

    }
}
