using Kubeleans.Kubernetes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Kubeleans.Kubernetes.Tests
{
    public class KubernetesClientTests : IClassFixture<KubernetesClientFixture>
    {
        private const int ApiRetryDelayMilliseconds = 500;
        private const int ApiDeleteDelayMilliseconds = 1000;
#if !DEBUG
        private const int ApiWatcherTimeoutMilliseconds = 10000;
#else
        private const int ApiWatcherTimeoutMilliseconds = 60000;
#endif
        private const int ApiCallMaxRetries = 5;

        private readonly KubernetesClientFixture fixture;

        public KubernetesClientTests(KubernetesClientFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task NamespaceApiTests()
        {
            var namespaceName = this.fixture.GetTemporaryObjectName("ns");

            var @namespace = new Namespace
            {
                ApiVersion = "v1",
                Kind = "Namespace",
                Metadata = new ObjectMeta
                {
                    Name = namespaceName
                }
            };

            //
            // Create namespace
            //

            var createdNamespace = await this.fixture.ApiClient.CreateNamespace(@namespace).ConfigureAwait(false);

            Assert.NotNull(createdNamespace);

            //
            // Ensure it is created by polling the object and checking its Status
            //

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledNamespace = await this.fixture.ApiClient.GetNamespace(namespaceName).ConfigureAwait(false);

                    return polledNamespace.Status.Phase == ObjectStatus.Active;
                }).ConfigureAwait(false);

            Assert.True(isCreated);

            //
            // List namespaces
            //

            var namespaces = await this.fixture.ApiClient.ListNamespaces().ConfigureAwait(false);

            Assert.NotNull(namespaces);
            Assert.NotNull(namespaces.Items.FirstOrDefault(n => n.Metadata.Name == namespaceName));

            //
            // Replace namespace with an updated definition
            //

            @namespace = await this.fixture.ApiClient.GetNamespace(namespaceName).ConfigureAwait(false);

            @namespace.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedNamespace = await this.fixture.ApiClient.ReplaceNamespace(@namespace).ConfigureAwait(false);

            Assert.NotNull(replacedNamespace);

            //
            // Watch namespace changes
            //

            var cts = new CancellationTokenSource();
            var reset = new ManualResetEventSlim(false);
            var watchException = default(Exception);

            var watcher = new KubernetesWatcher<Namespace>((value) =>
            {
                //
                // Look for the deleted namespace in the list of changes
                //

                if (value.Type == WatchTypes.Deleted && value.Object.Metadata.Name == namespaceName)
                {
                    reset.Set();
                }

                return Task.CompletedTask;
            },
            (exception) =>
            {
                watchException = exception;

                reset.Set();

                return Task.CompletedTask;
            });

            var task = Task.Run(async () => await this.fixture.ApiClient.WatchNamespaceChanges(watcher, cts.Token).ConfigureAwait(false));

            //
            // Delete namespace
            //

            // Need to wait with the delete operation to make sure watcher catches up and gets the changes
            await Task.Delay(ApiDeleteDelayMilliseconds).ConfigureAwait(false);

            var deletedNamespace = await this.fixture.ApiClient.DeleteNamespace(namespaceName).ConfigureAwait(false);

            Assert.NotNull(deletedNamespace);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task.ConfigureAwait(false);

            // Verify that we had no exception during watch
            Assert.Null(watchException);
        }

        [Fact]
        public async Task CustomResourceDefinitionApiTests()
        {
            var baseName = this.fixture.GetTemporaryObjectName("crd");
            var customResourceDefinitionName = $"{baseName}s.kubeleans.io";

            var customResourceDefinition = new CustomResourceDefinition
            {
                ApiVersion = "apiextensions.k8s.io/v1beta1",
                Kind = "CustomResourceDefinition",
                Metadata = new ObjectMeta
                {
                    Name = customResourceDefinitionName,
                    Labels = new Dictionary<string, string>() {
                        { "component", "kubeleans" }
                    }
                },
                Spec = new CustomResourceDefinitionSpec
                {
                    Group = "kubeleans.io",
                    Version = "v1",
                    Scope = "Namespaced",
                    Names = new CustomResourceDefinitionNames
                    {
                        Plural = baseName + "s",
                        Singular = baseName,
                        Kind = this.fixture.GetKind(baseName),
                        ShortNames = new List<string> { this.fixture.GetShortName(baseName) }
                    }
                }
            };

            //
            // Create customResourceDefinition
            //

            var createdCustomResourceDefinition = await this.fixture.ApiClient.CreateCustomResourceDefinition(customResourceDefinition).ConfigureAwait(false);

            Assert.NotNull(createdCustomResourceDefinition);

            //
            // Ensure it is created by polling the object and checking its Status
            //

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledCustomResourceDefinition = await this.fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName).ConfigureAwait(false);

                    return polledCustomResourceDefinition.Status.Conditions.FirstOrDefault(c => string.Compare(c.Status, "true", StringComparison.InvariantCultureIgnoreCase) == 0) != null;
                }).ConfigureAwait(false);

            Assert.True(isCreated);

            //
            // List CustomResourceDefinitions
            //

            var customResourceDefinitions = await this.fixture.ApiClient.ListCustomResourceDefinitions().ConfigureAwait(false);

            Assert.NotNull(customResourceDefinitions);
            Assert.NotNull(customResourceDefinitions.Items.FirstOrDefault(n => n.Metadata.Name == customResourceDefinitionName));

            //
            // Replace customResourceDefinition with an updated definition
            //

            customResourceDefinition = await this.fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName).ConfigureAwait(false);

            customResourceDefinition.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedCustomResourceDefinition = await this.fixture.ApiClient.ReplaceCustomResourceDefinition(customResourceDefinition).ConfigureAwait(false);

            Assert.NotNull(replacedCustomResourceDefinition);

            //
            // Watch customResourceDefinition changes
            //

            var cts = new CancellationTokenSource();
            var reset = new ManualResetEventSlim(false);
            var watchException = default(Exception);

            var watcher = new KubernetesWatcher<CustomResourceDefinition>((value) =>
            {
                //
                // Look for the deleted customResourceDefinition in the list of changes
                //

                if (value.Type == WatchTypes.Deleted && value.Object.Metadata.Name == customResourceDefinitionName)
                {
                    reset.Set();
                }

                return Task.CompletedTask;
            },
            (exception) =>
            {
                watchException = exception;

                reset.Set();

                return Task.CompletedTask;
            });

            var task = Task.Run(async () => await this.fixture.ApiClient.WatchCustomResourceDefinitionChanges(watcher, cts.Token).ConfigureAwait(false));

            //
            // Delete customResourceDefinition
            //

            // Need to wait with the delete operation to make sure watcher catches up and gets the changes
            await Task.Delay(ApiDeleteDelayMilliseconds).ConfigureAwait(false);

            var deletedCustomResourceDefinition = await this.fixture.ApiClient.DeleteCustomResourceDefinition(customResourceDefinitionName).ConfigureAwait(false);

            Assert.NotNull(deletedCustomResourceDefinition);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task.ConfigureAwait(false);

            // Verify that we had no exception during watch
            Assert.Null(watchException);
        }

        [Fact]
        public async Task CustomObjectApiTests()
        {
            var namespaceName = this.fixture.Namespace;

            //
            // Create the namespace specified in ApiClient options.
            //

            var @namespace = new Namespace
            {
                ApiVersion = "v1",
                Kind = "Namespace",
                Metadata = new ObjectMeta
                {
                    Name = namespaceName
                }
            };

            var createdNamespace = await this.fixture.ApiClient.CreateNamespace(@namespace).ConfigureAwait(false);

            Assert.NotNull(createdNamespace);

            //
            // Create a CRD for our GrainFunction
            //

            var baseName = this.fixture.GetTemporaryObjectName("crd");
            var group = "kubeleans.io";
            var customResourceDefinitionName = $"{baseName}s.{group}";

            var customResourceDefinition = new CustomResourceDefinition
            {
                ApiVersion = "apiextensions.k8s.io/v1beta1",
                Kind = "CustomResourceDefinition",
                Metadata = new ObjectMeta
                {
                    Name = customResourceDefinitionName,
                    Labels = new Dictionary<string, string>() {
                        { "component", "kubeleans" }
                    }
                },
                Spec = new CustomResourceDefinitionSpec
                {
                    Group = group,
                    Version = "v1",
                    Scope = "Namespaced",
                    Names = new CustomResourceDefinitionNames
                    {
                        Plural = baseName + "s",
                        Singular = baseName,
                        Kind = this.fixture.GetKind(baseName),
                        ShortNames = new List<string> { this.fixture.GetShortName(baseName) }
                    }
                }
            };

            var createdCustomResourceDefinition = await this.fixture.ApiClient.CreateCustomResourceDefinition(customResourceDefinition).ConfigureAwait(false);

            Assert.NotNull(createdCustomResourceDefinition);

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledCustomResourceDefinition = await this.fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName).ConfigureAwait(false);

                    return polledCustomResourceDefinition.Status.Conditions.FirstOrDefault(c => string.Compare(c.Status, "true", StringComparison.InvariantCultureIgnoreCase) == 0) != null;
                }).ConfigureAwait(false);

            Assert.True(isCreated);

            //
            // Create a GrainFunction Custom Object
            //

            var grainFunctionName = this.fixture.GetTemporaryObjectName("gf");

            var grainFunction = new GrainFunction
            {
                ApiVersion = "kubeleans.io/v1",
                Kind = customResourceDefinition.Spec.Names.Kind,
                Metadata = new ObjectMeta
                {
                    Name = grainFunctionName
                },
                Spec = new GrainFunctionSpec
                {
                    Binding = "http",
                    Image = "httpgrains",
                    Version = "v1"
                }
            };

            var createdCustomObject = await this.fixture.ApiClient.CreateCustomObject(customResourceDefinition.Spec.Names.Plural, grainFunction).ConfigureAwait(false);

            //
            // List CustomObjects
            //

            var customObjects = await this.fixture.ApiClient.ListCustomObjects<GrainFunctionList>(customResourceDefinition.Spec.Names.Plural).ConfigureAwait(false);

            Assert.NotNull(customObjects);
            Assert.NotNull(customObjects.Items.FirstOrDefault(n => n.Metadata.Name == grainFunctionName));

            //
            // Replace GrainFunction with an updated definition
            //

            grainFunction = await this.fixture.ApiClient.GetCustomObject<GrainFunction>(customResourceDefinition.Spec.Names.Plural, grainFunctionName).ConfigureAwait(false);

            grainFunction.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedGrainFunction = await this.fixture.ApiClient.ReplaceCustomObject(customResourceDefinition.Spec.Names.Plural, grainFunction).ConfigureAwait(false);

            //
            // Watch GrainFunction changes
            //

            var cts = new CancellationTokenSource();
            var reset = new ManualResetEventSlim(false);
            var watchException = default(Exception);

            var watcher = new KubernetesWatcher<GrainFunction>((value) =>
            {
                //
                // Look for the deleted customResourceDefinition in the list of changes
                //

                if (value.Type == WatchTypes.Deleted && value.Object.Metadata.Name == grainFunctionName)
                {
                    reset.Set();
                }

                return Task.CompletedTask;
            },
            (exception) =>
            {
                watchException = exception;

                reset.Set();

                return Task.CompletedTask;
            });

            var task = Task.Run(async () => await this.fixture.ApiClient.WatchCustomObjectChanges(customResourceDefinition.Spec.Names.Plural, watcher, cancellationToken: cts.Token).ConfigureAwait(false));

            //
            // Delete GrainFunction
            //

            // Need to wait with the delete operation to make sure watcher catches up and gets the changes
            await Task.Delay(ApiDeleteDelayMilliseconds).ConfigureAwait(false);

            var deletedGrainFunction = await this.fixture.ApiClient.DeleteCustomObject<GrainFunction>(customResourceDefinition.Spec.Names.Plural, grainFunctionName).ConfigureAwait(false);

            Assert.NotNull(deletedGrainFunction);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task.ConfigureAwait(false);

            // Verify that we had no exception during watch
            Assert.Null(watchException);

            //
            // Tead down created base objects
            //

            var deletedCustomResourceDefinition = await this.fixture.ApiClient.DeleteCustomResourceDefinition(customResourceDefinitionName).ConfigureAwait(false);

            Assert.NotNull(deletedCustomResourceDefinition);

            var deletedNamespace = await this.fixture.ApiClient.DeleteNamespace(namespaceName).ConfigureAwait(false);

            Assert.NotNull(deletedNamespace);
        }

        private async Task<bool> PollWithPredicate(Func<Task<bool>> predicate, Func<KubernetesApiException, Task<bool>> exceptionPredicate = null)
        {
            var result = false;
            var retries = 0;

            while (retries < ApiCallMaxRetries)
            {
                try
                {
                    if (await predicate().ConfigureAwait(false))
                    {
                        result = true;

                        break;
                    }
                }
                catch (KubernetesApiException ex)
                {
                    if (exceptionPredicate == null || (exceptionPredicate != null && await exceptionPredicate(ex).ConfigureAwait(false)))
                    {
                        result = true;

                        break;
                    }
                }

                await Task.Delay(ApiRetryDelayMilliseconds).ConfigureAwait(false);

                retries++;
            }

            return result;
        }
    }
}
