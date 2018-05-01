using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Kubeleans.Kubernetes
{
    public static class KubernetesClientExtensions
    {
        public static Task<TResult> GetAsync<TResult>(this KubernetesClient kubernetesClient, string url, IEnumerable<KeyValuePair<string, string>> queryParameters = default, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default)
            => kubernetesClient.SendAsync<TResult>(url, HttpMethod.Get, queryParameters, addDefaultLabelSelector: addDefaultLabelSelector, cancellationToken: cancellationToken);

        public static Task<TResult> PostAsync<TPayload, TResult>(this KubernetesClient kubernetesClient, string url, IEnumerable<KeyValuePair<string, string>> queryParameters = default, TPayload payload = default, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default) where TPayload : class
            => kubernetesClient.SendAsync<TResult>(url, HttpMethod.Post, queryParameters, payload, addDefaultLabelSelector: addDefaultLabelSelector, cancellationToken: cancellationToken);

        public static Task<TResult> PutAsync<TPayload, TResult>(this KubernetesClient kubernetesClient, string url, IEnumerable<KeyValuePair<string, string>> queryParameters = default, TPayload payload = default, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default) where TPayload : class
            => kubernetesClient.SendAsync<TResult>(url, HttpMethod.Put, queryParameters, payload, addDefaultLabelSelector: addDefaultLabelSelector, cancellationToken: cancellationToken);

        public static Task<TResult> DeleteAsync<TResult>(this KubernetesClient kubernetesClient, string url, IEnumerable<KeyValuePair<string, string>> queryParameters = default, bool addDefaultLabelSelector = false, CancellationToken cancellationToken = default)
            => kubernetesClient.SendAsync<TResult>(url, HttpMethod.Delete, queryParameters, addDefaultLabelSelector: addDefaultLabelSelector, cancellationToken: cancellationToken);
    }
}
