using GestorDeTurnos.Application.Constants;
using Microsoft.AspNetCore.Identity;

namespace GestorDeTurnos.Identity.Seeds
{
    /// <summary>
    /// Provides a seed of default user-role associations for identity management.
    /// </summary>
    public static class UserRoleSeed
    {
        /// <summary>
        /// Gets the default values for user-role associations.
        /// </summary>
        public static readonly IReadOnlyList<IdentityUserRole<string>> DefaultValues = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string>
            {
                UserId = UserSeed.DefaultValues.First(x => x.UserName == "propietario").Id,
                RoleId = RoleSeed.DefaultValues.First(x => x.Name == Role.Custom).Id
            },
            new IdentityUserRole<string>
            {
                UserId = UserSeed.DefaultValues.First(x => x.UserName == "propietario").Id,
                RoleId = RoleSeed.DefaultValues.First(x => x.Name == Role.Owner).Id
            },
            new IdentityUserRole<string>
            {
                UserId = UserSeed.DefaultValues.First(x => x.UserName == "empleado").Id,
                RoleId = RoleSeed.DefaultValues.First(x => x.Name == Role.Custom).Id
            },
            new IdentityUserRole<string>
            {
                UserId = UserSeed.DefaultValues.First(x => x.UserName == "empleado").Id,
                RoleId = RoleSeed.DefaultValues.First(x => x.Name == Role.Employee).Id
            },
            new IdentityUserRole<string>
            {
                UserId = UserSeed.DefaultValues.First(x => x.UserName == "cliente").Id,
                RoleId = RoleSeed.DefaultValues.First(x => x.Name == Role.Custom).Id
            },
        };
    }
}