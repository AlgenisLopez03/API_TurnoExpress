using Asp.Versioning.ApiExplorer;

namespace GestorDeTurnos.Application.Setups
{
    /// <summary>
    /// Static class for setting up versioned API Explorer options.
    /// </summary>
    public static class VersionedApiExplorerSetup
    {
        /// <summary>
        /// Configures the API Explorer options for API versioning.
        /// </summary>
        public static readonly Action<ApiExplorerOptions> Configure = options =>
        {
            // Sets the format of the API version in group names.
            options.GroupNameFormat = "'v'VVV";

            // Enables substitution of the API version in the URL path.
            options.SubstituteApiVersionInUrl = true;
        };
    }
}