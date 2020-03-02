using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Kubeleans.Abstractions.Triggers.Timer
{
    internal interface ITimerGrain : IGrainWithStringKey
    {
        Task Register(Immutable<TimeSpan> startFrom, Immutable<TimeSpan> tickEvery);
        Task Unregister();
    }
}