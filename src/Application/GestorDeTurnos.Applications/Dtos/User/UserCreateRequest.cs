﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.User
{
    public class UserCreateRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

        public string? ProfileImage { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password id limited to {2} to {1}", MinimumLength = 6)]
        public string Password { get; set; }
    }
}