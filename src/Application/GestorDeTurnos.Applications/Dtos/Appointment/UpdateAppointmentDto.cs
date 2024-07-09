using GestorDeTurnos.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class UpdateAppointmentDto : IHasId<int>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

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