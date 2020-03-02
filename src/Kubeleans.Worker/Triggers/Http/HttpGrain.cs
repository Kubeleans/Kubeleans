using System;
using System.Threading.Tasks;
using Kubeleans.Abstractions.Triggers.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Runtime;

namespace Kubeleans.Triggers.Http
{
    internal abstract class HttpGrain : Grain, IHttpGrain
    {
        private readonly IServiceProvider _serviceProvider;
        private HttpId _id;
        private ILogger _logger;
        private IHttpFunction _function;

        public HttpGrain(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public override Task OnActivateAsync()
        {
            this._id = HttpId.Parse(this.GetPrimaryKeyString());
            this._logger = this._serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(this._id.FunctionType);
            this._function = this._serviceProvider.GetRequiredServiceByName<IHttpFunction>(this._id.FunctionType);
            return Task.CompletedTask;
        }
    }
}