using GestorDeTurnos.Application.Dtos.Employee;
using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Application.Dtos.Service;
using GestorDeTurnos.Application.Dtos.Status;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class AppointmentDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int ServiceId { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
        public int Position { get; set; }
        public int EmployeeId { get; set; }

        public StatusDetailDto? Status { get; set; }
        public EstablishmentDetailDto? Establishment { get; set; }
        public ServiceDetailDto? Service { get; set; }
        public EmployeeDetailDto? Employee { get; set; }
    }
}