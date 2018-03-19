using Kubeleans.KubernetesAPI;
using Kubeleans.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Kubeleans.Tests
{
    public class APITest : IClassFixture<KubeAPIFixture>
    {
        private Kubernetes _kubeClient;

        public APITest(KubeAPIFixture fixture)
        {
            this._kubeClient = fixture.Client;
        }

        [Fact]
        public async Task CreateFunctionObjectTest()
        {
            var version = "v1";
            var appName = "test-app";
            var app = new GrainFunctionApplication { Name = appName };

            var appResult = await this._kubeClient.CreateCustomObject(version, "grainfunctionapplications", app);
            Assert.NotNull(appResult);

            var function = new GrainFunction
            {
                Name = "TEST error",
                ApplicationName = appName,
                ActivationMode = FunctionActivationMode.AlwaysOn,
                Runtime = FunctionRuntime.Go
            };

            //FIXME: Check the regex
            //await Assert.ThrowsAsync<ArgumentException>(() => this._kubeClient.CreateCustomObject("v1", "grainfunctions", function));

            function.Name = "test-function";
            var result = await this._kubeClient.CreateCustomObject(version, "grainfunctions", function);
            Assert.NotNull(result);
            await this._kubeClient.DeleteCustomObject(function.Name, "v1", "grainfunctions");
            await this._kubeClient.DeleteCustomObject(appName, "v1", "grainfunctionapplications");
        }
    }
}
