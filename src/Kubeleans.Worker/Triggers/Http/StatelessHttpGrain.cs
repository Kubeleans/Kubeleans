using System;
using Orleans.Concurrency;

namespace Kubeleans.Triggers.Http
{
    [StatelessWorker]
    internal class StatelessHttpGrain : HttpGrain
    {
        public StatelessHttpGrain(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}