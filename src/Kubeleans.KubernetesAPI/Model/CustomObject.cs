using System;
using System.Text.RegularExpressions;

namespace Kubeleans.KubernetesAPI.Model
{
    public abstract class CustomObject
    {
        // TODO: Fix this regex
        private const string NAME_REGEX_PATTERN = @"[a-z0-9]([-a-z0-9]*[a-z0-9])?(\.[a-z0-9]([-a-z0-9]*[a-z0-9])?)*";
        private const string INVALID_NAME_MESSAGE = "Function names must consist of lower case alphanumeric characters, '-' or '.', and must start and end with an alphanumeric character.";
        private static readonly Regex _nameValidator = new Regex(NAME_REGEX_PATTERN);

        public string ApiVersion { get; protected set; }
        public string Kind { get; protected set; }
        public ObjectMetadata Metadata { get; private set; } = new ObjectMetadata();

        internal void InternalValidate()
        {
            if (string.IsNullOrWhiteSpace(this.ApiVersion)) throw new ArgumentNullException(nameof(this.ApiVersion));
            if (string.IsNullOrWhiteSpace(this.Kind)) throw new ArgumentNullException(nameof(this.Kind));
            if (string.IsNullOrWhiteSpace(this.Metadata.Name)) throw new ArgumentNullException(nameof(this.Metadata.Name));
            if (!_nameValidator.Match(this.Metadata.Name).Success) throw new ArgumentException(INVALID_NAME_MESSAGE);
            
            this.Validate();
        }

        protected virtual void Validate() { }
    }
}
