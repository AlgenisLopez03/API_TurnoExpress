using Asp.Versioning;

namespace GestorDeTurnos.Application.Setups.Swagger
{
    /// <summary>
    /// Static class for setting up API versioning options.
    /// </summary>
    public static class ApiVersionSetup
    {
        /// <summary>
        /// Configures API versioning options.
        /// </summary>
        public static readonly Action<ApiVersioningOptions> Configure = options =>
        {
            // Sets the default API version to 1.0.
            options.DefaultApiVersion = new ApiVersion(1, 0);

            // Assumes the default version when an API version is not specified in the request.
            options.AssumeDefaultVersionWhenUnspecified = true;

            // Includes headers to inform the client which versions are supported.
            options.ReportApiVersions = true;
        };
    }
}