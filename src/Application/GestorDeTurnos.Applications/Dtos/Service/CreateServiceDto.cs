using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Service
{
    public class CreateServiceDto
    {
        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public string ServiceImage { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}