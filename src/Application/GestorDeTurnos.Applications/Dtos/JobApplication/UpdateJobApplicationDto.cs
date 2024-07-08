
using GestorDeTurnos.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace GestorDeTurnos.Application.Dtos.JobApplication
{
    public class UpdateJobApplicationDto : IHasId<int>
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
