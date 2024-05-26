namespace GestorDeTurnos.Application.Dtos.Service
{
    public class ServiceDetailDto
    {
        public int Id { get; set; }
        public int EstablishmentId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceImage { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
    }
}