using System;

namespace Kubeleans.Triggers.Http
{
    internal class StatefulHttpGrain : HttpGrain
    {
        public StatefulHttpGrain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}