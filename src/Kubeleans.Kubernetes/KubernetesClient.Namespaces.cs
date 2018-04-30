using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        public Task<NamespaceList> ListNamespaces(CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/api/v1/namespaces";

            return this.GetAsync<NamespaceList>(url, cancellationToken: cancellationToken);
        }

        public Task<Namespace> CreateNamespace(Namespace @namespace, CancellationToken cancellationToken = default)
        {
            if (@namespace==null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            var url = $"{options.BaseUrl}/api/v1/namespaces";

            return this.PostAsync<Namespace, Namespace>(url, payload: @namespace, cancellationToken: cancellationToken);
        }

        public Task<Namespace> ReplaceNamespace(string namespaceName, Namespace @namespace, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                throw new ArgumentNullException(nameof(namespaceName));
            }

            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            var url = $"{options.BaseUrl}/api/v1/namespaces/{namespaceName}";

            return this.PutAsync<Namespace, Namespace>(url, payload: @namespace, cancellationToken: cancellationToken);
        }

        public Task<Namespace> GetNamespace(string namespaceName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                throw new ArgumentNullException(nameof(namespaceName));
            }

            var url = $"{options.BaseUrl}/api/v1/namespaces/{namespaceName}";

            return this.GetAsync<Namespace>(url, cancellationToken: cancellationToken);
        }

        public Task<Namespace> DeleteNamespace(string namespaceName, CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/api/v1/namespaces/{namespaceName}";

            return this.DeleteAsync<Namespace>(url, immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public Task WatchNamespaceChanges(IKubernetesWatcher<Namespace> watcher, CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/api/v1/namespaces";

            return WatchObjectChangesAsync(url, cancellationToken, watcher);
        }
    }
}
