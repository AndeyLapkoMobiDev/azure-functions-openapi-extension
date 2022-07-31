using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Functions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.AppSettings.Extensions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations.AppSettings.Resolvers;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions
{
    /// <summary>
    /// This represents the extensions entity to configure OpenAPI capability to Azure Functions out-of-process worker.
    /// </summary>
    public static class OpenApiFunctionsWorkerApplicationBuilderExtensions
    {
        private const string OpenApiSettingsKey = "OpenApi";

        /// <summary>
        /// Configures to use app settings for OpenAPI.
        /// </summary>
        /// <param name="applicationBuilder"><see cref="IFunctionsWorkerApplicationBuilder"/> instance.</param>
        /// <returns>Returns <see cref="IFunctionsWorkerApplicationBuilder"/> instance.</returns>
        public static IFunctionsWorkerApplicationBuilder ConfigureAppSettings(this IFunctionsWorkerApplicationBuilder applicationBuilder)
        {
            var config = ConfigurationResolver.Resolve();
            var settings = config.Get<OpenApiSettings>(OpenApiSettingsKey);

            applicationBuilder.Services.AddSingleton(settings);

            return applicationBuilder;
        }

        /// <summary>
        /// Configures to use OpenAPI features.
        /// </summary>
        /// <param name="applicationBuilder"><see cref="IFunctionsWorkerApplicationBuilder"/> instance.</param>
        /// <returns>Returns <see cref="IFunctionsWorkerApplicationBuilder"/> instance.</returns>
        public static IFunctionsWorkerApplicationBuilder ConfigureOpenApi(this IFunctionsWorkerApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddSingleton<IOpenApiHttpTriggerContext, OpenApiHttpTriggerContext>();
            applicationBuilder.Services.AddSingleton<IOpenApiTriggerFunction, OpenApiTriggerFunction>();
            // applicationBuilder.Services.AddSingleton<DefaultOpenApiHttpTrigger, DefaultOpenApiHttpTrigger>();

            return applicationBuilder;
        }
    }
}
