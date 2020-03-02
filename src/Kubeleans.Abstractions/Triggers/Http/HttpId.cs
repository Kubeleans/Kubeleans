using System;

namespace Kubeleans.Abstractions.Triggers.Http
{
    internal struct HttpId
    {
        public string Name { get; }
        public string FunctionType { get; }
        public string Route { get; }
        public string[] Verbs { get; }

        private HttpId(string functionType, string name, string route, string verbs = "*")
        {
            this.Name = name;
            this.FunctionType = functionType;
            this.Route = route;

            var verbsParts = verbs.Split('|');

            if (verbsParts != null && verbsParts.Length > 0)
            {
                this.Verbs = verbsParts;
            }
            else
            {
                this.Verbs = new[] { "*" };
            }
        }

        /// <summary>
        /// Parse a string into a HttpId.
        /// The string must conform with the 'Http-{FunctionType}-{Name}-{Route}-{Verbs}' format.
        /// </summary>
        /// <param name="id">String id to be parsed.</param>
        /// <returns>HttpId struct.</returns>
        public static HttpId Parse(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException(nameof(id));

            var parts = id.Split("-");
            if (parts.Length != 5) throw new InvalidOperationException("Invalid HttpId format.");

            return new HttpId(parts[1], parts[2], parts[3], parts[4]);
        }

        public override string ToString()
        {
            return $"Timer-{this.FunctionType}-{this.Name}";
        }
    }
}