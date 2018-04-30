using Kubeleans.Kubernetes.Models;

namespace Kubeleans.Kubernetes.Tests
{
    public class GrainFunction : CustomObject
    {
        public GrainFunctionSpec Spec { get; set; }
    }
}
