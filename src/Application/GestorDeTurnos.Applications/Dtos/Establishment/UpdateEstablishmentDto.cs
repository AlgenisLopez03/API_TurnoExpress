using GestorDeTurnos.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Establishment
{
    public class UpdateEstablishmentDto : IHasId<int>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Range(1, int.MaxValue)]
        public int ServiceId { get; set; }

        [Range(1, int.MaxValue)]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }
    }
}