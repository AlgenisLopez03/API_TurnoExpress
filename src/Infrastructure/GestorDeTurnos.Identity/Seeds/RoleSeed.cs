using GestorDeTurnos.Application.Constants;
using Microsoft.AspNetCore.Identity;

namespace GestorDeTurnos.Identity.Seeds
{
    /// <summary>
    /// Provides a seed of default roles for identity management.
    /// </summary>
    public static class RoleSeed
    {
        /// <summary>
        /// Gets the default values for Identity roles.
        /// </summary>
        public static readonly IReadOnlyList<IdentityRole<string>> DefaultValues = new List<IdentityRole<string>>
    {
        new IdentityRole
        {
            Name = Role.Owner,
            NormalizedName = Role.Owner.ToUpper()
        },
        new IdentityRole
        {
            Name = Role.Custom,
            NormalizedName = Role.Custom.ToUpper()
        }
    };
    }
}