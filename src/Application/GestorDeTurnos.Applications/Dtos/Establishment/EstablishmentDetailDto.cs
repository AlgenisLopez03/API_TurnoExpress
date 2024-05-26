namespace GestorDeTurnos.Application.Dtos.Establishment
{
    public class EstablishmentDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BusinessName { get; set; }
        public string Location { get; set; }
        public string WorkingHours { get; set; }
        public string Description { get; set; }
        public string ProfileImage { get; set; }
    }
}