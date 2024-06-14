
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.User
{
    public class UserUpdateRequest
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        public IFormFile? ImageFile { get; set; }

        [Required]
        public string ProfileImage { get; set; }


    }
}
