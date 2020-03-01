using Kubeleans.Kubernetes.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public partial class KubernetesClient
    {
        private static class CustomObjectUrls
        {
            internal static string BaseUrl(string version, string @namespace, string objectPluralName) => $"apis/{Group}/{version}/namespaces/{@namespace}/{objectPluralName}";
            internal static string ObjectUrl(string version, string @namespace, string objectPluralName, string customObjectName) => $"apis/{Group}/{version}/namespaces/{@namespace}/{objectPluralName}/{customObjectName}";
        }

        public ValueTask<T> ListCustomObjects<T>(string objectPluralName, string version = Version1, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return this.GetAsync<T>(CustomObjectUrls.BaseUrl(version, this.options.Namespace, objectPluralName), cancellationToken: cancellationToken);
        }

        public ValueTask<T> CreateCustomObject<T>(string objectPluralName, T customObject, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrEmpty(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (customObject == null)
            {
                throw new ArgumentNullException(nameof(customObject));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return this.PostAsync<T, T>(CustomObjectUrls.BaseUrl(version, this.options.Namespace, objectPluralName), payload: customObject, cancellationToken: cancellationToken);
        }

        public ValueTask<T> ReplaceCustomObject<T>(string objectPluralName, T customObject, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
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
                throw new ArgumentNullException(nameof(customObject.Metadata.Name), "Metadata.Name is required.");
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return this.PutAsync<T, T>(CustomObjectUrls.ObjectUrl(version, this.options.Namespace, objectPluralName, customObject.Metadata.Name), payload: customObject, cancellationToken: cancellationToken);
        }

        public ValueTask<T> GetCustomObject<T>(string objectPluralName, string customObjectName, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (string.IsNullOrWhiteSpace(customObjectName))
            {
                throw new ArgumentNullException(nameof(customObjectName));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return this.GetAsync<T>(CustomObjectUrls.ObjectUrl(version, this.options.Namespace, objectPluralName, customObjectName), cancellationToken: cancellationToken);
        }

        public ValueTask<T> DeleteCustomObject<T>(string objectPluralName, string customObjectName, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (string.IsNullOrWhiteSpace(customObjectName))
            {
                throw new ArgumentNullException(nameof(customObjectName));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return this.DeleteAsync<T>(CustomObjectUrls.ObjectUrl(version, this.options.Namespace, objectPluralName, customObjectName), immediateDeleteOptions, cancellationToken: cancellationToken);
        }

        public ValueTask WatchCustomObjectChanges<T>(string objectPluralName, IKubernetesWatcher<T> watcher, string version = Version1, CancellationToken cancellationToken = default) where T : CustomObject, new()
        {
            if (string.IsNullOrWhiteSpace(objectPluralName))
            {
                throw new ArgumentNullException(nameof(objectPluralName));
            }

            if (watcher == null)
            {
                throw new ArgumentNullException(nameof(watcher));
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new ArgumentNullException(nameof(version));
            }

            return WatchObjectChangesAsync(CustomObjectUrls.BaseUrl(version, this.options.Namespace, objectPluralName), cancellationToken, watcher);
        }
    }
}
