namespace GestorDeTurnos.Application.Dtos.Appointment
{
    public class AppointmentDetailDto
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public int Position { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}