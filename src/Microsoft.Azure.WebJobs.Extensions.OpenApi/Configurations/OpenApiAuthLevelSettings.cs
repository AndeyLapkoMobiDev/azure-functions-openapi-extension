using System;

using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Microsoft.Azure.WebJobs.Extensions.OpenApi.Configurations
{
    /// <summary>
    /// This represents the environment variable settings entity for OpenAPI document auth level.
    /// </summary>
    [Obsolete("It's deprecated and will be removed from v2.0.0. Use Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations.OpenApiAuthLevelSettings instead.")]
    public class OpenApiAuthLevelSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="AuthorizationLevel"/> value for OpenAPI document rendering endpoints.
        /// </summary>
        public virtual AuthorizationLevel? Document { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="AuthorizationLevel"/> value for Swagger UI page rendering endpoints.
        /// </summary>
        public virtual AuthorizationLevel? UI { get; set; }
    }
}
