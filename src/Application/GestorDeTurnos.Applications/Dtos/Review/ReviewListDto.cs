namespace GestorDeTurnos.Application.Dtos.Review
{
    public class ReviewListDto
    {
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}