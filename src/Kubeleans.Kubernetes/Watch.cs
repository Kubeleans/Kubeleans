using System;

namespace Kubeleans.Kubernetes
{
    public sealed class Watch<T>
    {
        public Watch(string type, T @object)
        {
            this.Type = (WatchTypes)Enum.Parse(typeof(WatchTypes), type, true);
            this.Object = @object;
        }

        public WatchTypes Type { get; }

        public T Object { get; }
    }
}
