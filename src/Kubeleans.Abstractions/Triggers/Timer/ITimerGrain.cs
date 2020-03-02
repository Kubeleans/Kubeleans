using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Concurrency;

namespace Kubeleans.Abstractions.Triggers.Timer
{
    public interface ITimerGrain : IGrainWithStringKey
    {
        Task Register(Immutable<TimeSpan> startOn, Immutable<TimeSpan> happensEvery);
        Task Unregister();
    }
}