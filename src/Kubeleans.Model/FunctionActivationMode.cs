namespace Kubeleans.Model
{
    /// <summary>
    /// The function activation mode
    /// </summary>
    public enum FunctionActivationMode
    {
        /// <summary>
        /// Will be activated based on a configured trigger (i.e. message, http, tcp, etc).
        /// Functions in trigger mode gets deactivated when idle.
        /// </summary>
        Trigger = 0,
        /// <summary>
        /// Will be activated at the system startup and kept alive as long as the cluster is up.
        /// Functions in AlwaysOn mode will never be deactivated.
        /// Also, functions on this mode are replicated with a configurable number of replicas.
        /// </summary>
        AlwaysOn = 1
    }
}
