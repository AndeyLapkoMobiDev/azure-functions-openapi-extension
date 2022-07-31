using Azure.Core.Serialization;

using Microsoft.Azure.Functions.Worker.Core;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

[assembly: WorkerExtensionStartup(typeof(OpenApiWorkerExtensionStartup))]

namespace Microsoft.Azure.Functions.Worker.Extensions.OpenApi
{
    /// <summary>
    /// This represents the startup entity for OpenAPI endpoints registration
    /// </summary>
    public class OpenApiWorkerExtensionStartup : WorkerExtensionStartup
    {
        /// <inheritdoc />
        public override void Configure(IFunctionsWorkerApplicationBuilder applicationBuilder)
        {
            var settings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;

            applicationBuilder.UseNewtonsoftJson(settings)
                              //.ConfigureAppSettings()
                              .ConfigureOpenApi();
        }
    }
}
