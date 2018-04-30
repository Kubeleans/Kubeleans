using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        public Task<CustomResourceDefinitionList> ListCustomResourceDefinitions(CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions";

            return this.GetAsync<CustomResourceDefinitionList>(url, cancellationToken: cancellationToken);
        }

        public Task<CustomResourceDefinition> CreateCustomResourceDefinition(CustomResourceDefinition customResourceDefinition, CancellationToken cancellationToken = default)
        {
            if (customResourceDefinition == null)
            {
                throw new ArgumentNullException(nameof(customResourceDefinition));
            }

            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions";

            return this.PostAsync<CustomResourceDefinition, CustomResourceDefinition>(url, payload: customResourceDefinition, cancellationToken: cancellationToken);
        }

        public Task<CustomResourceDefinition> ReplaceCustomResourceDefinition(string customResourceDefinitionName, CustomResourceDefinition customResourceDefinition, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customResourceDefinitionName))
            {
                throw new ArgumentNullException(nameof(customResourceDefinitionName));
            }

            if (customResourceDefinition == null)
            {
                throw new ArgumentNullException(nameof(customResourceDefinition));
            }

            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions/{customResourceDefinitionName}";

            return this.PutAsync<CustomResourceDefinition, CustomResourceDefinition>(url, payload: customResourceDefinition, cancellationToken: cancellationToken);
        }

        public Task<CustomResourceDefinition> GetCustomResourceDefinition(string customResourceDefinitionName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(customResourceDefinitionName))
            {
                throw new ArgumentNullException(nameof(customResourceDefinitionName));
            }

            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions/{customResourceDefinitionName}";

            return this.GetAsync<CustomResourceDefinition>(url, cancellationToken: cancellationToken);
        }

        public Task<CustomResourceDefinition> DeleteCustomResourceDefinition(string customResourceDefinitionName, CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions/{customResourceDefinitionName}";

            return this.DeleteAsync<CustomResourceDefinition>(url, immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public Task WatchCustomResourceDefinitionChanges(IKubernetesWatcher<CustomResourceDefinition> watcher, CancellationToken cancellationToken = default)
        {
            var url = $"{options.BaseUrl}/apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions";

            return WatchObjectChangesAsync(url, cancellationToken, watcher);
        }
    }
}
