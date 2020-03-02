using System;

namespace Kubeleans.Abstractions.Triggers.Timer
{
    public struct TimerId
    {
        public string Name { get; }
        public string FunctionType { get; }

        private TimerId(string functionType, string name)
        {
            this.Name = name;
            this.FunctionType = functionType;
        }

        /// <summary>
        /// Parse a string into a TimerId.
        /// The string must conform with the 'Timer-{FunctionType}-{Name}' format.
        /// </summary>
        /// <param name="id">String id to be parsed.</param>
        /// <returns>TimerId struct.</returns>
        public static TimerId Parse(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var parts = id.Split("-");
            if (parts.Length != 3) throw new InvalidOperationException("Invalid TimerId format.");

            return new TimerId(parts[1], parts[2]);
        }

        public override string ToString()
        {
            return $"Timer-{this.FunctionType}-{this.Name}";
        }
    }
}