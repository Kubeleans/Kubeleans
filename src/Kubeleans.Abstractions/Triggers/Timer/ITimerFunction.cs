using System;
using System.Threading.Tasks;

namespace Kubeleans.Abstractions.Triggers.Timer
{
    public interface ITimerFunction : IKubeleansFunction
    {
        ValueTask Execute(string name, DateTimeOffset lastExecution);
    }
}