using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Establishment
{
    public class EstablishmentFilterAndPaginationDto : PaginationBase
    {
        public string? UserId { get; set; }
        public string? BusinessName { get; set; }
        public string? Location { get; set; }
        public string? WorkingHours { get; set; }
        public string? Description { get; set; }
    }
}