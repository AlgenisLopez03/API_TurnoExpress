
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Employee
{
    public class CreateEmployeeDto
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Required]
        public bool Availabe { get; set; }

    }
}