using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        private static class CustomResourceDefinitionUrls
        {
            internal static string BaseUrl => "apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions";
            internal static string ObjectUrl(string customResourceDefinitionName) => $"apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions/{customResourceDefinitionName}";
        }

        public ValueTask<CustomResourceDefinitionList> ListCustomResourceDefinitions(CancellationToken cancellationToken = default) => this.GetAsync<CustomResourceDefinitionList>(CustomResourceDefinitionUrls.BaseUrl, cancellationToken: cancellationToken);

        public ValueTask<CustomResourceDefinition> CreateCustomResourceDefinition(CustomResourceDefinition customResourceDefinition, CancellationToken cancellationToken = default)
        {
            if (customResourceDefinition == null)
            {
                throw new ArgumentNullException(nameof(customResourceDefinition));
            }

            return this.PostAsync<CustomResourceDefinition, CustomResourceDefinition>(CustomResourceDefinitionUrls.BaseUrl, payload: customResourceDefinition, cancellationToken: cancellationToken);
        }

        public ValueTask<CustomResourceDefinition> ReplaceCustomResourceDefinition(CustomResourceDefinition customResourceDefinition, CancellationToken cancellationToken = default)
        {
            if (customResourceDefinition == null)
            {
                throw new ArgumentNullException(nameof(customResourceDefinition));
            }

            if (customResourceDefinition.Metadata == null || string.IsNullOrWhiteSpace(customResourceDefinition.Metadata.Name))
            {
                throw new ArgumentNullException(nameof(customResourceDefinition.Metadata.Name), "Metadata.Name is required.");
            }

            return this.PutAsync<CustomResourceDefinition, CustomResourceDefinition>(CustomResourceDefinitionUrls.ObjectUrl(customResourceDefinition.Metadata.Name), payload: customResourceDefinition, cancellationToken: cancellationToken);
        }

        public ValueTask<CustomResourceDefinition> GetCustomResourceDefinition(string customResourceDefinitionName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customResourceDefinitionName))
            {
                throw new ArgumentNullException(nameof(customResourceDefinitionName));
            }

            return this.GetAsync<CustomResourceDefinition>(CustomResourceDefinitionUrls.ObjectUrl(customResourceDefinitionName), cancellationToken: cancellationToken);
        }

        public ValueTask<CustomResourceDefinition> DeleteCustomResourceDefinition(string customResourceDefinitionName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customResourceDefinitionName))
            {
                throw new ArgumentNullException(nameof(customResourceDefinitionName));
            }

            return this.DeleteAsync<CustomResourceDefinition>(CustomResourceDefinitionUrls.ObjectUrl(customResourceDefinitionName), immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public ValueTask WatchCustomResourceDefinitionChanges(IKubernetesWatcher<CustomResourceDefinition> watcher, CancellationToken cancellationToken = default)
        {
            if (watcher == null)
            {
                throw new ArgumentNullException(nameof(watcher));
            }

            return WatchObjectChangesAsync(CustomResourceDefinitionUrls.BaseUrl, cancellationToken, watcher);
        }
    }
}
