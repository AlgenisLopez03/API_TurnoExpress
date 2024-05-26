using Microsoft.AspNetCore.Identity;

namespace GestorDeTurnos.Identity.Models
{
    public class CustomIdentityUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}