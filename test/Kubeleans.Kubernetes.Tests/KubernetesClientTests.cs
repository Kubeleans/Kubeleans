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
        private const int ApiDelayMilliseconds = 500;
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
            var namespaceName = fixture.GetTemporaryObjectName("ns");

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

            var createdNamespace = await fixture.ApiClient.CreateNamespace(@namespace);

            Assert.NotNull(createdNamespace);

            //
            // Ensure it is created by polling the object and checking its Status
            //

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledNamespace = await fixture.ApiClient.GetNamespace(namespaceName);

                    return polledNamespace.Status.Phase == ObjectStatus.Active;
                });

            Assert.True(isCreated);

            //
            // List namespaces
            //

            var namespaces = await fixture.ApiClient.ListNamespaces();

            Assert.NotNull(namespaces);
            Assert.NotNull(namespaces.Items.FirstOrDefault(n => n.Metadata.Name == namespaceName));

            //
            // Replace namespace with an updated definition
            //

            @namespace = await fixture.ApiClient.GetNamespace(namespaceName);

            @namespace.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedNamespace = await fixture.ApiClient.ReplaceNamespace(namespaceName, @namespace);

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

            var task = Task.Run(() => fixture.ApiClient.WatchNamespaceChanges(watcher, cts.Token));

            //
            // Delete namespace
            //

            var deletedNamespace = await fixture.ApiClient.DeleteNamespace(namespaceName);

            Assert.NotNull(deletedNamespace);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task;

            // Verify that we had no exception during watch
            Assert.Null(watchException);
        }

        [Fact]
        public async Task CustomResourceDefinitionApiTests()
        {
            var baseName = fixture.GetTemporaryObjectName("crd");
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
                        Kind = fixture.GetKind(baseName),
                        ShortNames = new List<string> { fixture.GetShortName(baseName) }
                    }
                }
            };

            //
            // Create customResourceDefinition
            //

            var createdCustomResourceDefinition = await fixture.ApiClient.CreateCustomResourceDefinition(customResourceDefinition);

            Assert.NotNull(createdCustomResourceDefinition);

            //
            // Ensure it is created by polling the object and checking its Status
            //

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledCustomResourceDefinition = await fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName);

                    return polledCustomResourceDefinition.Status.Conditions.FirstOrDefault(c => String.Compare(c.Status, "true", StringComparison.InvariantCultureIgnoreCase) == 0) != null;
                });

            Assert.True(isCreated);

            //
            // List CustomResourceDefinitions
            //

            var customResourceDefinitions = await fixture.ApiClient.ListCustomResourceDefinitions();

            Assert.NotNull(customResourceDefinitions);
            Assert.NotNull(customResourceDefinitions.Items.FirstOrDefault(n => n.Metadata.Name == customResourceDefinitionName));

            //
            // Replace customResourceDefinition with an updated definition
            //

            customResourceDefinition = await fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName);

            customResourceDefinition.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedCustomResourceDefinition = await fixture.ApiClient.ReplaceCustomResourceDefinition(customResourceDefinitionName, customResourceDefinition);

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

            var task = Task.Run(() => fixture.ApiClient.WatchCustomResourceDefinitionChanges(watcher, cts.Token));

            //
            // Delete customResourceDefinition
            //

            var deletedCustomResourceDefinition = await fixture.ApiClient.DeleteCustomResourceDefinition(customResourceDefinitionName);

            Assert.NotNull(deletedCustomResourceDefinition);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task;

            // Verify that we had no exception during watch
            Assert.Null(watchException);
        }

        [Fact]
        public async Task CustomObjectApiTests()
        {
            var namespaceName = fixture.Namespace;

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

            var createdNamespace = await fixture.ApiClient.CreateNamespace(@namespace);

            Assert.NotNull(createdNamespace);

            //
            // Create a CRD for our GrainFunction
            //

            var baseName = fixture.GetTemporaryObjectName("crd");
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
                        Kind = fixture.GetKind(baseName),
                        ShortNames = new List<string> { fixture.GetShortName(baseName) }
                    }
                }
            };

            var createdCustomResourceDefinition = await fixture.ApiClient.CreateCustomResourceDefinition(customResourceDefinition);

            Assert.NotNull(createdCustomResourceDefinition);

            var isCreated = await PollWithPredicate(
                async () =>
                {
                    var polledCustomResourceDefinition = await fixture.ApiClient.GetCustomResourceDefinition(customResourceDefinitionName);

                    return polledCustomResourceDefinition.Status.Conditions.FirstOrDefault(c => String.Compare(c.Status, "true", StringComparison.InvariantCultureIgnoreCase) == 0) != null;
                });

            Assert.True(isCreated);

            //
            // Create a GrainFunction Custom Object
            //

            var grainFunctionName = fixture.GetTemporaryObjectName("gf");

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

            var createdCustomObject = await fixture.ApiClient.CreateCustomObject(customResourceDefinition.Spec.Names.Plural, grainFunction);

            //
            // List CustomObjects
            //

            var customObjects = await fixture.ApiClient.ListCustomObjects<GrainFunctionList>(customResourceDefinition.Spec.Names.Plural);

            Assert.NotNull(customObjects);
            Assert.NotNull(customObjects.Items.FirstOrDefault(n => n.Metadata.Name == grainFunctionName));

            //
            // Replace GrainFunction with an updated definition
            //

            grainFunction = await fixture.ApiClient.GetCustomObject<GrainFunction>(customResourceDefinition.Spec.Names.Plural, grainFunctionName);

            grainFunction.Metadata.Labels = new Dictionary<string, string>
            {
                ["L1"] = "Test"
            };

            var replacedGrainFunction = await fixture.ApiClient.ReplaceCustomObject(customResourceDefinition.Spec.Names.Plural, grainFunction);

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

            var task = Task.Run(() => fixture.ApiClient.WatchCustomObjectChanges(customResourceDefinition.Spec.Names.Plural, watcher, cancellationToken: cts.Token));

            //
            // Delete GrainFunction
            //

            var deletedGrainFunction = await fixture.ApiClient.DeleteCustomObject<GrainFunction>(customResourceDefinition.Spec.Names.Plural, grainFunctionName);

            Assert.NotNull(deletedGrainFunction);

            // Wait for watchers to be called and event signaled or time out
            Assert.True(reset.Wait(ApiWatcherTimeoutMilliseconds));

            cts.Cancel();

            await task;

            // Verify that we had no exception during watch
            Assert.Null(watchException);

            //
            // Tead down created base objects
            //

            var deletedCustomResourceDefinition = await fixture.ApiClient.DeleteCustomResourceDefinition(customResourceDefinitionName);

            Assert.NotNull(deletedCustomResourceDefinition);

            var deletedNamespace = await fixture.ApiClient.DeleteNamespace(namespaceName);

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
                    if (await predicate())
                    {
                        result = true;

                        break;
                    }
                }
                catch (KubernetesApiException ex)
                {
                    if (exceptionPredicate == null || (exceptionPredicate != null && await exceptionPredicate(ex)))
                    {
                        result = true;

                        break;
                    }
                }

                await Task.Delay(ApiDelayMilliseconds);

                retries++;
            }

            return result;
        }
    }
}
