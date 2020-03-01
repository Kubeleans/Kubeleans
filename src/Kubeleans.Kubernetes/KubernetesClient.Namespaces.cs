using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        private static class NamespaceUrls
        {
            internal static string BaseUrl => "api/v1/namespaces";
            internal static string ObjectUrl(string namespaceName) => $"api/v1/namespaces/{namespaceName}";
        }

        public ValueTask<NamespaceList> ListNamespaces(CancellationToken cancellationToken = default) => this.GetAsync<NamespaceList>(NamespaceUrls.BaseUrl, cancellationToken: cancellationToken);

        public ValueTask<Namespace> CreateNamespace(Namespace @namespace, CancellationToken cancellationToken = default)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            return this.PostAsync<Namespace, Namespace>(NamespaceUrls.BaseUrl, payload: @namespace, cancellationToken: cancellationToken);
        }

        public ValueTask<Namespace> ReplaceNamespace(Namespace @namespace, CancellationToken cancellationToken = default)
        {
            if (@namespace == null)
            {
                throw new ArgumentNullException(nameof(@namespace));
            }

            if (@namespace.Metadata == null || string.IsNullOrWhiteSpace(@namespace.Metadata.Name))
            {
                throw new ArgumentNullException(nameof(@namespace.Metadata.Name), "Metadata.Name is required.");
            }

            return this.PutAsync<Namespace, Namespace>(NamespaceUrls.ObjectUrl(@namespace.Metadata.Name), payload: @namespace, cancellationToken: cancellationToken);
        }

        public ValueTask<Namespace> GetNamespace(string namespaceName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                throw new ArgumentNullException(nameof(namespaceName));
            }

            return this.GetAsync<Namespace>(NamespaceUrls.ObjectUrl(namespaceName), cancellationToken: cancellationToken);
        }

        public ValueTask<Namespace> DeleteNamespace(string namespaceName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(namespaceName))
            {
                throw new ArgumentNullException(nameof(namespaceName));
            }

            return this.DeleteAsync<Namespace>(NamespaceUrls.ObjectUrl(namespaceName), immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public ValueTask WatchNamespaceChanges(IKubernetesWatcher<Namespace> watcher, CancellationToken cancellationToken = default)
        {
            if (watcher == null)
            {
                throw new ArgumentNullException(nameof(watcher));
            }

            return WatchObjectChangesAsync(NamespaceUrls.BaseUrl, cancellationToken, watcher);
        }
    }
}
