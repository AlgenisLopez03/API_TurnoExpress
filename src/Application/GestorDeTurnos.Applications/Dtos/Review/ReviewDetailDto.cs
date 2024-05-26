namespace GestorDeTurnos.Application.Dtos.Review
{
    public class ReviewDetailDto
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}