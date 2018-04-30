namespace Kubeleans.Kubernetes.Models
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// CustomResourceDefinitionNames indicates the names to serve this
    /// CustomResourceDefinition
    /// </summary>
    public class CustomResourceDefinitionNames
    {

        /// <summary>
        /// Gets or sets categories is a list of grouped resources custom
        /// resources belong to (e.g. 'all')
        /// </summary>
        public IList<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets kind is the serialized kind of the resource.  It is
        /// normally CamelCase and singular.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets listKind is the serialized kind of the list for this
        /// resource.  Defaults to &amp;lt;kind&amp;gt;List.
        /// </summary>
        public string ListKind { get; set; }

        /// <summary>
        /// Gets or sets plural is the plural name of the resource to serve.
        /// It must match the name of the CustomResourceDefinition-registration
        /// too: plural.group and it must be all lowercase.
        /// </summary>
        public string Plural { get; set; }

        /// <summary>
        /// Gets or sets shortNames are short names for the resource.  It must
        /// be all lowercase.
        /// </summary>
        public IList<string> ShortNames { get; set; }

        /// <summary>
        /// Gets or sets singular is the singular name of the resource.  It
        /// must be all lowercase  Defaults to lowercased &amp;lt;kind&amp;gt;
        /// </summary>
        public string Singular { get; set; }
    }
}
