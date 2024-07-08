using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class CreateAppointmentDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int EstablishmentId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}