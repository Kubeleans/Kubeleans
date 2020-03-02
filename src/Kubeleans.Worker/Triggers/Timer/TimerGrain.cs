using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kubeleans.Abstractions.Triggers.Timer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Concurrency;
using Orleans.Runtime;

namespace Kubeleans.Triggers.Timer
{
    internal class TimerGrain : Grain, ITimerGrain, IRemindable
    {
        private readonly IServiceProvider _serviceProvider;
        private ILogger _logger;
        private TimerId _id;

        public TimerGrain(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public override Task OnActivateAsync()
        {
            this._id = TimerId.Parse(this.GetPrimaryKeyString());
            this._logger = this._serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(this._id.FunctionType);
            return Task.CompletedTask;
        }

        public async Task ReceiveReminder(string reminderName, TickStatus status)
        {
            // TODO: Add instrumentation
            ITimerFunction function;
            try
            {
                function = this._serviceProvider.GetRequiredServiceByName<ITimerFunction>(this._id.FunctionType);
                await function.Execute(this._id.Name, status.CurrentTickTime.Subtract(status.Period));
            }
            catch (KeyNotFoundException)
            {
                this._logger.LogWarning("Timer '{timer}' was fired but the function type '{function}' wasn't found. Ignoring tick.", this._id.Name, this._id.FunctionType);
            }
            catch (Exception exc)
            {
                this._logger.LogError(exc, "Failure invoking '{function}' function.", this._id.FunctionType);
            }
        }

        public Task Register(Immutable<TimeSpan> startFrom, Immutable<TimeSpan> tickEvery)
        {
            return this.RegisterOrUpdateReminder(this._id.Name, startFrom.Value, tickEvery.Value);
        }

        public async Task Unregister()
        {
            var reminder = await this.GetReminder(this._id.Name);
            if (reminder != null)
            {
                await this.UnregisterReminder(reminder);
            }
            else
            {
                this._logger.LogWarning("Attempt to unregister an inexistent timer: '{name}'.", this._id.Name);
            }
        }
    }
}