using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Report
{
    public class CreateReportDto
    {
        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Required]
        public decimal Revenue { get; set; }

        [Range(0, int.MaxValue)]
        public int AppointmentsCount { get; set; }
    }
}