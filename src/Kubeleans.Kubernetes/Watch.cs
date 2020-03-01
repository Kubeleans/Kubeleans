using System;
using System.Text.Json.Serialization;

namespace Kubeleans.Kubernetes
{
    // [JsonConverter(typeof(WatchConverter))]
    public sealed class Watch<T>
    {
        //TODO: To make this immutable again, fix WatchConverter
        // public Watch(string type, T @object)
        // {
        //     this.Type = (WatchTypes)Enum.Parse(typeof(WatchTypes), type, true);
        //     this.Object = @object;
        // }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WatchTypes Type { get; set; }

        public T Object { get; set; }
    }
}
