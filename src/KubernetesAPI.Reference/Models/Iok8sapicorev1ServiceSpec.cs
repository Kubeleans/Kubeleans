// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Kubeleans.KubernetesApi.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ServiceSpec describes the attributes that a user creates on a service.
    /// </summary>
    public partial class Iok8sapicorev1ServiceSpec
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1ServiceSpec class.
        /// </summary>
        public Iok8sapicorev1ServiceSpec()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapicorev1ServiceSpec class.
        /// </summary>
        /// <param name="clusterIP">clusterIP is the IP address of the service
        /// and is usually assigned randomly by the master. If an address is
        /// specified manually and is not in use by others, it will be
        /// allocated to the service; otherwise, creation of the service will
        /// fail. This field can not be changed through updates. Valid values
        /// are "None", empty string (""), or a valid IP address. "None" can be
        /// specified for headless services when proxying is not required. Only
        /// applies to types ClusterIP, NodePort, and LoadBalancer. Ignored if
        /// type is ExternalName. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies</param>
        /// <param name="externalIPs">externalIPs is a list of IP addresses for
        /// which nodes in the cluster will also accept traffic for this
        /// service.  These IPs are not managed by Kubernetes.  The user is
        /// responsible for ensuring that traffic arrives at a node with this
        /// IP.  A common example is external load-balancers that are not part
        /// of the Kubernetes system.</param>
        /// <param name="externalName">externalName is the external reference
        /// that kubedns or equivalent will return as a CNAME record for this
        /// service. No proxying will be involved. Must be a valid RFC-1123
        /// hostname (https://tools.ietf.org/html/rfc1123) and requires Type to
        /// be ExternalName.</param>
        /// <param name="externalTrafficPolicy">externalTrafficPolicy denotes
        /// if this Service desires to route external traffic to node-local or
        /// cluster-wide endpoints. "Local" preserves the client source IP and
        /// avoids a second hop for LoadBalancer and Nodeport type services,
        /// but risks potentially imbalanced traffic spreading. "Cluster"
        /// obscures the client source IP and may cause a second hop to another
        /// node, but should have good overall load-spreading.</param>
        /// <param name="healthCheckNodePort">healthCheckNodePort specifies the
        /// healthcheck nodePort for the service. If not specified,
        /// HealthCheckNodePort is created by the service api backend with the
        /// allocated nodePort. Will use user-specified nodePort value if
        /// specified by the client. Only effects when Type is set to
        /// LoadBalancer and ExternalTrafficPolicy is set to Local.</param>
        /// <param name="loadBalancerIP">Only applies to Service Type:
        /// LoadBalancer LoadBalancer will get created with the IP specified in
        /// this field. This feature depends on whether the underlying
        /// cloud-provider supports specifying the loadBalancerIP when a load
        /// balancer is created. This field will be ignored if the
        /// cloud-provider does not support the feature.</param>
        /// <param name="loadBalancerSourceRanges">If specified and supported
        /// by the platform, this will restrict traffic through the
        /// cloud-provider load-balancer will be restricted to the specified
        /// client IPs. This field will be ignored if the cloud-provider does
        /// not support the feature." More info:
        /// https://kubernetes.io/docs/tasks/access-application-cluster/configure-cloud-provider-firewall/</param>
        /// <param name="ports">The list of ports that are exposed by this
        /// service. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies</param>
        /// <param name="publishNotReadyAddresses">publishNotReadyAddresses,
        /// when set to true, indicates that DNS implementations must publish
        /// the notReadyAddresses of subsets for the Endpoints associated with
        /// the Service. The default value is false. The primary use case for
        /// setting this field is to use a StatefulSet's Headless Service to
        /// propagate SRV records for its Pods without respect to their
        /// readiness for purpose of peer discovery. This field will replace
        /// the service.alpha.kubernetes.io/tolerate-unready-endpoints when
        /// that annotation is deprecated and all clients have been converted
        /// to use this field.</param>
        /// <param name="selector">Route service traffic to pods with label
        /// keys and values matching this selector. If empty or not present,
        /// the service is assumed to have an external process managing its
        /// endpoints, which Kubernetes will not modify. Only applies to types
        /// ClusterIP, NodePort, and LoadBalancer. Ignored if type is
        /// ExternalName. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/</param>
        /// <param name="sessionAffinity">Supports "ClientIP" and "None". Used
        /// to maintain session affinity. Enable client IP based session
        /// affinity. Must be ClientIP or None. Defaults to None. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies</param>
        /// <param name="sessionAffinityConfig">sessionAffinityConfig contains
        /// the configurations of session affinity.</param>
        /// <param name="type">type determines how the Service is exposed.
        /// Defaults to ClusterIP. Valid options are ExternalName, ClusterIP,
        /// NodePort, and LoadBalancer. "ExternalName" maps to the specified
        /// externalName. "ClusterIP" allocates a cluster-internal IP address
        /// for load-balancing to endpoints. Endpoints are determined by the
        /// selector or if that is not specified, by manual construction of an
        /// Endpoints object. If clusterIP is "None", no virtual IP is
        /// allocated and the endpoints are published as a set of endpoints
        /// rather than a stable IP. "NodePort" builds on ClusterIP and
        /// allocates a port on every node which routes to the clusterIP.
        /// "LoadBalancer" builds on NodePort and creates an external
        /// load-balancer (if supported in the current cloud) which routes to
        /// the clusterIP. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#publishing-services---service-types</param>
        public Iok8sapicorev1ServiceSpec(string clusterIP = default(string), IList<string> externalIPs = default(IList<string>), string externalName = default(string), string externalTrafficPolicy = default(string), int? healthCheckNodePort = default(int?), string loadBalancerIP = default(string), IList<string> loadBalancerSourceRanges = default(IList<string>), IList<Iok8sapicorev1ServicePort> ports = default(IList<Iok8sapicorev1ServicePort>), bool? publishNotReadyAddresses = default(bool?), IDictionary<string, string> selector = default(IDictionary<string, string>), string sessionAffinity = default(string), Iok8sapicorev1SessionAffinityConfig sessionAffinityConfig = default(Iok8sapicorev1SessionAffinityConfig), string type = default(string))
        {
            ClusterIP = clusterIP;
            ExternalIPs = externalIPs;
            ExternalName = externalName;
            ExternalTrafficPolicy = externalTrafficPolicy;
            HealthCheckNodePort = healthCheckNodePort;
            LoadBalancerIP = loadBalancerIP;
            LoadBalancerSourceRanges = loadBalancerSourceRanges;
            Ports = ports;
            PublishNotReadyAddresses = publishNotReadyAddresses;
            Selector = selector;
            SessionAffinity = sessionAffinity;
            SessionAffinityConfig = sessionAffinityConfig;
            Type = type;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets clusterIP is the IP address of the service and is
        /// usually assigned randomly by the master. If an address is specified
        /// manually and is not in use by others, it will be allocated to the
        /// service; otherwise, creation of the service will fail. This field
        /// can not be changed through updates. Valid values are "None", empty
        /// string (""), or a valid IP address. "None" can be specified for
        /// headless services when proxying is not required. Only applies to
        /// types ClusterIP, NodePort, and LoadBalancer. Ignored if type is
        /// ExternalName. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies
        /// </summary>
        [JsonProperty(PropertyName = "clusterIP")]
        public string ClusterIP { get; set; }

        /// <summary>
        /// Gets or sets externalIPs is a list of IP addresses for which nodes
        /// in the cluster will also accept traffic for this service.  These
        /// IPs are not managed by Kubernetes.  The user is responsible for
        /// ensuring that traffic arrives at a node with this IP.  A common
        /// example is external load-balancers that are not part of the
        /// Kubernetes system.
        /// </summary>
        [JsonProperty(PropertyName = "externalIPs")]
        public IList<string> ExternalIPs { get; set; }

        /// <summary>
        /// Gets or sets externalName is the external reference that kubedns or
        /// equivalent will return as a CNAME record for this service. No
        /// proxying will be involved. Must be a valid RFC-1123 hostname
        /// (https://tools.ietf.org/html/rfc1123) and requires Type to be
        /// ExternalName.
        /// </summary>
        [JsonProperty(PropertyName = "externalName")]
        public string ExternalName { get; set; }

        /// <summary>
        /// Gets or sets externalTrafficPolicy denotes if this Service desires
        /// to route external traffic to node-local or cluster-wide endpoints.
        /// "Local" preserves the client source IP and avoids a second hop for
        /// LoadBalancer and Nodeport type services, but risks potentially
        /// imbalanced traffic spreading. "Cluster" obscures the client source
        /// IP and may cause a second hop to another node, but should have good
        /// overall load-spreading.
        /// </summary>
        [JsonProperty(PropertyName = "externalTrafficPolicy")]
        public string ExternalTrafficPolicy { get; set; }

        /// <summary>
        /// Gets or sets healthCheckNodePort specifies the healthcheck nodePort
        /// for the service. If not specified, HealthCheckNodePort is created
        /// by the service api backend with the allocated nodePort. Will use
        /// user-specified nodePort value if specified by the client. Only
        /// effects when Type is set to LoadBalancer and ExternalTrafficPolicy
        /// is set to Local.
        /// </summary>
        [JsonProperty(PropertyName = "healthCheckNodePort")]
        public int? HealthCheckNodePort { get; set; }

        /// <summary>
        /// Gets or sets only applies to Service Type: LoadBalancer
        /// LoadBalancer will get created with the IP specified in this field.
        /// This feature depends on whether the underlying cloud-provider
        /// supports specifying the loadBalancerIP when a load balancer is
        /// created. This field will be ignored if the cloud-provider does not
        /// support the feature.
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancerIP")]
        public string LoadBalancerIP { get; set; }

        /// <summary>
        /// Gets or sets if specified and supported by the platform, this will
        /// restrict traffic through the cloud-provider load-balancer will be
        /// restricted to the specified client IPs. This field will be ignored
        /// if the cloud-provider does not support the feature." More info:
        /// https://kubernetes.io/docs/tasks/access-application-cluster/configure-cloud-provider-firewall/
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancerSourceRanges")]
        public IList<string> LoadBalancerSourceRanges { get; set; }

        /// <summary>
        /// Gets or sets the list of ports that are exposed by this service.
        /// More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies
        /// </summary>
        [JsonProperty(PropertyName = "ports")]
        public IList<Iok8sapicorev1ServicePort> Ports { get; set; }

        /// <summary>
        /// Gets or sets publishNotReadyAddresses, when set to true, indicates
        /// that DNS implementations must publish the notReadyAddresses of
        /// subsets for the Endpoints associated with the Service. The default
        /// value is false. The primary use case for setting this field is to
        /// use a StatefulSet's Headless Service to propagate SRV records for
        /// its Pods without respect to their readiness for purpose of peer
        /// discovery. This field will replace the
        /// service.alpha.kubernetes.io/tolerate-unready-endpoints when that
        /// annotation is deprecated and all clients have been converted to use
        /// this field.
        /// </summary>
        [JsonProperty(PropertyName = "publishNotReadyAddresses")]
        public bool? PublishNotReadyAddresses { get; set; }

        /// <summary>
        /// Gets or sets route service traffic to pods with label keys and
        /// values matching this selector. If empty or not present, the service
        /// is assumed to have an external process managing its endpoints,
        /// which Kubernetes will not modify. Only applies to types ClusterIP,
        /// NodePort, and LoadBalancer. Ignored if type is ExternalName. More
        /// info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/
        /// </summary>
        [JsonProperty(PropertyName = "selector")]
        public IDictionary<string, string> Selector { get; set; }

        /// <summary>
        /// Gets or sets supports "ClientIP" and "None". Used to maintain
        /// session affinity. Enable client IP based session affinity. Must be
        /// ClientIP or None. Defaults to None. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#virtual-ips-and-service-proxies
        /// </summary>
        [JsonProperty(PropertyName = "sessionAffinity")]
        public string SessionAffinity { get; set; }

        /// <summary>
        /// Gets or sets sessionAffinityConfig contains the configurations of
        /// session affinity.
        /// </summary>
        [JsonProperty(PropertyName = "sessionAffinityConfig")]
        public Iok8sapicorev1SessionAffinityConfig SessionAffinityConfig { get; set; }

        /// <summary>
        /// Gets or sets type determines how the Service is exposed. Defaults
        /// to ClusterIP. Valid options are ExternalName, ClusterIP, NodePort,
        /// and LoadBalancer. "ExternalName" maps to the specified
        /// externalName. "ClusterIP" allocates a cluster-internal IP address
        /// for load-balancing to endpoints. Endpoints are determined by the
        /// selector or if that is not specified, by manual construction of an
        /// Endpoints object. If clusterIP is "None", no virtual IP is
        /// allocated and the endpoints are published as a set of endpoints
        /// rather than a stable IP. "NodePort" builds on ClusterIP and
        /// allocates a port on every node which routes to the clusterIP.
        /// "LoadBalancer" builds on NodePort and creates an external
        /// load-balancer (if supported in the current cloud) which routes to
        /// the clusterIP. More info:
        /// https://kubernetes.io/docs/concepts/services-networking/service/#publishing-services---service-types
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

    }
}
