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
    /// CronJobStatus represents the current state of a cron job.
    /// </summary>
    public partial class Iok8sapibatchv1beta1CronJobStatus
    {
        /// <summary>
        /// Initializes a new instance of the Iok8sapibatchv1beta1CronJobStatus
        /// class.
        /// </summary>
        public Iok8sapibatchv1beta1CronJobStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Iok8sapibatchv1beta1CronJobStatus
        /// class.
        /// </summary>
        /// <param name="active">A list of pointers to currently running
        /// jobs.</param>
        /// <param name="lastScheduleTime">Information when was the last time
        /// the job was successfully scheduled.</param>
        public Iok8sapibatchv1beta1CronJobStatus(IList<Iok8sapicorev1ObjectReference> active = default(IList<Iok8sapicorev1ObjectReference>), System.DateTimeOffset? lastScheduleTime = default(System.DateTimeOffset?))
        {
            Active = active;
            LastScheduleTime = lastScheduleTime;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets a list of pointers to currently running jobs.
        /// </summary>
        [JsonProperty(PropertyName = "active")]
        public IList<Iok8sapicorev1ObjectReference> Active { get; set; }

        /// <summary>
        /// Gets or sets information when was the last time the job was
        /// successfully scheduled.
        /// </summary>
        [JsonProperty(PropertyName = "lastScheduleTime")]
        public System.DateTimeOffset? LastScheduleTime { get; set; }

    }
}
