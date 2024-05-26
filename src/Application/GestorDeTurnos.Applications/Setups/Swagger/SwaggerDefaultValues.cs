using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json;

namespace GestorDeTurnos.Application.Setups.Swagger
{
    /// <summary>
    /// A filter to apply default values and descriptions to Swagger operations.
    /// </summary>
    public class SwaggerDefaultValues : IOperationFilter
    {
        /// <summary>
        /// Applies the filter to an individual API operation.
        /// </summary>
        /// <param name="operation">The operation to be modified.</param>
        /// <param name="context">The current operation filter context.</param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;

            // Mark the operation as deprecated if the API version is deprecated.
            operation.Deprecated |= apiDescription.IsDeprecated();

            // Remove unsupported response content types.
            foreach (var responseType in context.ApiDescription.SupportedResponseTypes)
            {
                var responseKey = responseType.IsDefaultResponse ? "default" : responseType.StatusCode.ToString();
                var response = operation.Responses[responseKey];

                foreach (var contentType in response.Content.Keys)
                {
                    if (responseType.ApiResponseFormats.All(x => x.MediaType != contentType))
                    {
                        response.Content.Remove(contentType);
                    }
                }
            }

            // Skip further processing if there are no parameters.
            if (operation.Parameters == null)
            {
                return;
            }

            // Update parameter descriptions, default values, and required flag.
            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescription.ParameterDescriptions.First(p => p.Name == parameter.Name);

                parameter.Description ??= description.ModelMetadata?.Description;

                // Set default values for parameters if available.
                if (parameter.Schema.Default == null &&
                    description.DefaultValue != null &&
                    description.DefaultValue is not DBNull &&
                    description.ModelMetadata is ModelMetadata modelMetadata)
                {
                    var json = JsonSerializer.Serialize(description.DefaultValue, modelMetadata.ModelType);
                    parameter.Schema.Default = OpenApiAnyFactory.CreateFromJson(json);
                }

                // Mark parameter as required if it is required in the API model.
                parameter.Required |= description.IsRequired;
            }
        }
    }
}