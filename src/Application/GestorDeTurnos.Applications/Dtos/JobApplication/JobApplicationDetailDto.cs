
using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Application.Dtos.EstablishmentRole;

namespace GestorDeTurnos.Application.Dtos.JobApplication
{
    public class JobApplicationDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int EstablishmentId { get; set; }
        public int RoleId { get; set; }
        public string Status { get; set; }

        public EstablishmentDetailDto Establishment { get; set; }
        public EstablishmentRoleDetailDto Role { get; set; }
    }
}
