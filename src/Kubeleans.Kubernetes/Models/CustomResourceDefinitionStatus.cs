namespace Kubeleans.Kubernetes.Models
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// CustomResourceDefinitionStatus indicates the state of the
    /// CustomResourceDefinition
    /// </summary>
    public class CustomResourceDefinitionStatus
    {

        /// <summary>
        /// Gets or sets acceptedNames are the names that are actually being
        /// used to serve discovery They may be different than the names in
        /// spec.
        /// </summary>
        public CustomResourceDefinitionNames AcceptedNames { get; set; }

        /// <summary>
        /// Gets or sets conditions indicate state for particular aspects of a
        /// CustomResourceDefinition
        /// </summary>
        public IList<CustomResourceDefinitionCondition> Conditions { get; set; }
    }
}
