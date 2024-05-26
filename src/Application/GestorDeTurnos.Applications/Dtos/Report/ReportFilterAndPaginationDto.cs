using GestorDeTurnos.Application.Pagination;

namespace GestorDeTurnos.Application.Dtos.Report
{
    public class ReportFilterAndPaginationDto : PaginationBase
    {
        public string? Establishment { get; set; }
    }
}