namespace GestorDeTurnos.Application.Dtos.Report
{
    public class ReportDetailDto
    {
        public int Id { get; set; }
        public int EstablishmentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Revenue { get; set; }
        public int AppointmentsCount { get; set; }
    }
}