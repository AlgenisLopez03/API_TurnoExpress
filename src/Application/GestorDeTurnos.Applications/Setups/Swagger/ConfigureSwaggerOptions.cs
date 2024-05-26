using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GestorDeTurnos.Application.Setups.Swagger
{
    /// <summary>
    /// Configures Swagger options to support multiple API versions.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The provider that determines API version descriptions.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        /// <summary>
        /// Configures the Swagger generator options.
        /// </summary>
        /// <param name="options">The Swagger generation options.</param>
        public void Configure(SwaggerGenOptions options)
        {
            // Iterate through all API versions and create Swagger documentation for each version.
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        /// <summary>
        /// Creates Swagger OpenApi information for a specific API version.
        /// </summary>
        /// <param name="description">The API version description.</param>
        /// <returns>An OpenApiInfo object populated with API version information.</returns>
        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Gestor de Turnos Web API",
                Version = description.ApiVersion.ToString(),
                Description = "Description for the example Web API",
            };

            // Adds a note to the description if the API version is deprecated.
            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }
}