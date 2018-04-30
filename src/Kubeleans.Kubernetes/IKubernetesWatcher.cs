using System;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public interface IKubernetesWatcher<T> where T : new()
    {
        Task Change(Watch<T> value);
        Task Error(Exception exception);
    }
}
