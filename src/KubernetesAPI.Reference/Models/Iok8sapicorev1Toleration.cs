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
    /// The pod this Toleration is attached to tolerates any taint that matches
    /// the triple &lt;key,value,effect&gt; using the matching operator
    /// &lt;operator&gt;.
    /// </summary>
    public partial class Iok8sapicorev1Toleration
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1Toleration class.
        /// </summary>
        public Iok8sapicorev1Toleration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1Toleration class.
        /// </summary>
        /// <param name="effect">Effect indicates the taint effect to match.
        /// Empty means match all taint effects. When specified, allowed values
        /// are NoSchedule, PreferNoSchedule and NoExecute.</param>
        /// <param name="key">Key is the taint key that the toleration applies
        /// to. Empty means match all taint keys. If the key is empty, operator
        /// must be Exists; this combination means to match all values and all
        /// keys.</param>
        /// <param name="operatorProperty">Operator represents a key's
        /// relationship to the value. Valid operators are Exists and Equal.
        /// Defaults to Equal. Exists is equivalent to wildcard for value, so
        /// that a pod can tolerate all taints of a particular
        /// category.</param>
        /// <param name="tolerationSeconds">TolerationSeconds represents the
        /// period of time the toleration (which must be of effect NoExecute,
        /// otherwise this field is ignored) tolerates the taint. By default,
        /// it is not set, which means tolerate the taint forever (do not
        /// evict). Zero and negative values will be treated as 0 (evict
        /// immediately) by the system.</param>
        /// <param name="value">Value is the taint value the toleration matches
        /// to. If the operator is Exists, the value should be empty, otherwise
        /// just a regular string.</param>
        public Iok8sapicorev1Toleration(string effect = default(string), string key = default(string), string operatorProperty = default(string), long? tolerationSeconds = default(long?), string value = default(string))
        {
            Effect = effect;
            Key = key;
            OperatorProperty = operatorProperty;
            TolerationSeconds = tolerationSeconds;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets effect indicates the taint effect to match. Empty
        /// means match all taint effects. When specified, allowed values are
        /// NoSchedule, PreferNoSchedule and NoExecute.
        /// </summary>
        [JsonProperty(PropertyName = "effect")]
        public string Effect { get; set; }

        /// <summary>
        /// Gets or sets key is the taint key that the toleration applies to.
        /// Empty means match all taint keys. If the key is empty, operator
        /// must be Exists; this combination means to match all values and all
        /// keys.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets operator represents a key's relationship to the value.
        /// Valid operators are Exists and Equal. Defaults to Equal. Exists is
        /// equivalent to wildcard for value, so that a pod can tolerate all
        /// taints of a particular category.
        /// </summary>
        [JsonProperty(PropertyName = "operator")]
        public string OperatorProperty { get; set; }

        /// <summary>
        /// Gets or sets tolerationSeconds represents the period of time the
        /// toleration (which must be of effect NoExecute, otherwise this field
        /// is ignored) tolerates the taint. By default, it is not set, which
        /// means tolerate the taint forever (do not evict). Zero and negative
        /// values will be treated as 0 (evict immediately) by the system.
        /// </summary>
        [JsonProperty(PropertyName = "tolerationSeconds")]
        public long? TolerationSeconds { get; set; }

        /// <summary>
        /// Gets or sets value is the taint value the toleration matches to. If
        /// the operator is Exists, the value should be empty, otherwise just a
        /// regular string.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

    }
}
