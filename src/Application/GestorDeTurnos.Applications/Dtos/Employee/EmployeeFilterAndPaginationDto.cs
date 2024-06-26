
using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Employee
{
    public class EmployeeFilterAndPaginationDto : PaginationBase
    {
        public string? UserId { get; set; }
        public int? EstablishmentId { get; set; }
        public bool Availabe { get; set; }
    } 
}
