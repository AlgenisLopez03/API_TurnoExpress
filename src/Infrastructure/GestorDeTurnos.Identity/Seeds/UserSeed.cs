using GestorDeTurnos.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GestorDeTurnos.Identity.Seeds
{
    /// <summary>
    /// Provides a seed of default users for identity management.
    /// </summary>
    public static class UserSeed
    {
        private static readonly PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();

        /// <summary>
        /// Gets the default values for ApplicationUsers.
        /// </summary>
        public static readonly IReadOnlyList<CustomIdentityUser> DefaultValues = new List<CustomIdentityUser>
        {
            new CustomIdentityUser
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "johnDoe",
                NormalizedUserName = "JOHNDOE",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(new CustomIdentityUser(), "123Pa$$word")
            },
            new CustomIdentityUser
            {
                FirstName = "John",
                LastName = "Smith",
                UserName = "jonhSmith",
                NormalizedUserName = "JONHSMITH",
                Email = "basic@gmail.com",
                NormalizedEmail = "BASIC@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(new CustomIdentityUser(), "123Pa$$word")
            }
        };
    }
}