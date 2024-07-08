
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.JobApplication
{
    public class CreateJobApplicationDto
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; } 
        
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
