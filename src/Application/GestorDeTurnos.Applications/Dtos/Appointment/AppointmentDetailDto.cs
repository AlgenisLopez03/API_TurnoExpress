using GestorDeTurnos.Application.Enums;

namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class AppointmentDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public int Position { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
    }
}