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
                UserName = "propietario",
                NormalizedUserName = "PROPIETARIO",
                ProfileImage = "",
                Email = "propietario@gmail.com",
                NormalizedEmail = "PROPIETARIO@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "000-000-0001",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(new CustomIdentityUser(), "Pa$$word123")
            },
            new CustomIdentityUser
            {
                FirstName = "John",
                LastName = "Smith",
                UserName = "empleado",
                NormalizedUserName = "EMPLEADO",
                ProfileImage = "",
                Email = "empleado@gmail.com",
                NormalizedEmail = "EMPLEADO@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "000-000-0002",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(new CustomIdentityUser(), "Pa$$word123")
            },
            new CustomIdentityUser
            {
                FirstName = "John",
                LastName = "Tie",
                UserName = "cliente",
                NormalizedUserName = "CLIENTE",
                ProfileImage = "",
                Email = "cliente@gmail.com",
                NormalizedEmail = "CLIENTE@GMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "000-000-0000",
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(new CustomIdentityUser(), "Pa$$word123")
            }
        };
    }
}