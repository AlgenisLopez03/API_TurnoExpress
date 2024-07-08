using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.JobApplication
{
    public class JobApplicationFilterAndPaginationDto : PaginationBase
    { 
        public int? EstablishmentId { get; set; }
        public string? UserId { get; set; }
        public string? Status { get; set; }
    }
}
