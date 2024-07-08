
namespace GestorDeTurnos.Application.Dtos.JobApplication
{
    public class JobApplicationListDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }
    }
}
