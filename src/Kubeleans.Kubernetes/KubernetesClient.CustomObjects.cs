using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        public Task<T> ListCustomObjects<T>(string objectPluralName, string version = Version1, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}";

            return this.GetAsync<T>(url, cancellationToken: cancellationToken);
        }

        public Task<T> CreateCustomObject<T>(string objectPluralName, T customObject, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrEmpty(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (customObject == null)
            {
                throw new ArgumentNullException(nameof(customObject));
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}";

            return this.PostAsync<T, T>(url, payload: customObject, cancellationToken: cancellationToken);
        }

        public Task<T> ReplaceCustomObject<T>(string objectPluralName, T customObject, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (customObject == null)
            {
                throw new ArgumentNullException(nameof(customObject));
            }

            if (customObject.Metadata == null || string.IsNullOrWhiteSpace(customObject.Metadata.Name))
            {
                throw new ArgumentNullException(nameof(customObject.Metadata.Name), "customObject.Metadata.Name is required.");
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}/{customObject.Metadata.Name}";

            return this.PutAsync<T, T>(url, payload: customObject, cancellationToken: cancellationToken);
        }

        public Task<T> GetCustomObject<T>(string objectPluralName, string customObjectName, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (string.IsNullOrWhiteSpace(customObjectName))
            {
                throw new ArgumentNullException(nameof(customObjectName));
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}/{customObjectName}";

            return this.GetAsync<T>(url, cancellationToken: cancellationToken);
        }

        public Task<T> DeleteCustomObject<T>(string objectPluralName, string customObjectName, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (string.IsNullOrWhiteSpace(customObjectName))
            {
                throw new ArgumentNullException(nameof(customObjectName));
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}/{customObjectName}";

            return this.DeleteAsync<T>(url, immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public Task WatchCustomObjectChanges<T>(string objectPluralName, IKubernetesWatcher<T> watcher, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject, new()
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            var url = $"{options.BaseUrl}/apis/{Group}/{version}/namespaces/{options.Namespace}/{objectPluralName}";

            return WatchObjectChangesAsync(url, cancellationToken, watcher);
        }
    }
}
