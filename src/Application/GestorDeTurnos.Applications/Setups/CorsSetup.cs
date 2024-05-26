using Microsoft.AspNetCore.Cors.Infrastructure;

namespace GestorDeTurnos.Application.Setups
{
    /// <summary>
    /// Static class for setting up Cross-Origin Resource Sharing (CORS) options.
    /// </summary>
    public static class CorsSetup
    {
        /// <summary>
        /// Configures CORS options.
        /// </summary>
        public static readonly Action<CorsOptions> Configure = options =>
        {
            // Adds a CORS policy named "AllowAll" that allows any origin, method, and header.
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowAnyOrigin());
        };
    }
}