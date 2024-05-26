using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GestorDeTurnos.Application.Setups.Swagger
{
    /// <summary>
    /// Static class for setting up Swagger generation options.
    /// </summary>
    public static class SwaggerGenSetup
    {
        /// <summary>
        /// Configures Swagger generation options.
        /// </summary>
        public static readonly Action<SwaggerGenOptions> Configure = options =>
        {
            // Adds the SwaggerDefaultValues operation filter to the Swagger options.
            options.OperationFilter<SwaggerDefaultValues>();

            // Adds security definition for JWT bearer authentication.
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme.
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: Bearer 12345abcdef",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

            // Adds a security requirement for JWT bearer authentication to all API endpoints.
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    },
                    Scheme = "oauth2",
                    Name = JwtBearerDefaults.AuthenticationScheme,
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
        };
    }
}