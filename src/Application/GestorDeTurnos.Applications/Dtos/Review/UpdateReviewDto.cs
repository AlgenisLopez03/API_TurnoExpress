using GestorDeTurnos.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.Review
{
    public class UpdateReviewDto : IHasId<int>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int EstablishmentId { get; set; }

        [Range(1, int.MaxValue)]
        public int Rating { get; set; }

        [Required]
        public string Comment { get; set; }

    }
}