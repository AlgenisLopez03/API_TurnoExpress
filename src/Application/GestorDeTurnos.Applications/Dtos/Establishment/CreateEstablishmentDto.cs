using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Establishment
{
    public class CreateEstablishmentDto
    {
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

        [Required]
        public string ProfileImage { get; set; }
    }
}