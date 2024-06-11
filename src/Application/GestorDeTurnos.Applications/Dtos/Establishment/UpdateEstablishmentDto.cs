using GestorDeTurnos.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Establishment
{
    public class UpdateEstablishmentDto : IHasId<int>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string WorkingHours { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile? ImageFile { get; set; }

        public string? ProfileImage { get; set; }
    }
}