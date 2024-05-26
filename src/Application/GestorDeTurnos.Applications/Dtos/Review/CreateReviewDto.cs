using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Review
{
    public class CreateReviewDto
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Range(1, int.MaxValue)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}