using System;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public class KubernetesWatcher<T> : IKubernetesWatcher<T> where T : new()
    {
        private readonly Func<Watch<T>, Task> changeHandler;
        private readonly Func<Exception, Task> errorHandler;

        public KubernetesWatcher(Func<Watch<T>, Task> changeHandler, Func<Exception, Task> errorHandler = default)
        {
            this.changeHandler = changeHandler ?? throw new ArgumentNullException(nameof(changeHandler));
            this.errorHandler = errorHandler;
        }

        public Task Change(Watch<T> value) => this.changeHandler(value);

        public Task Error(Exception exception) => this.errorHandler ==null ? Task.CompletedTask : this.errorHandler(exception);
    }
}
