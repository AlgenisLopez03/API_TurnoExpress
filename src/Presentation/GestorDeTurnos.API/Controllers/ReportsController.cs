using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Report;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(ApplicationDbContext context, IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<ReportListDto>>>> GetAllReportsAsync([FromQuery] ReportFilterAndPaginationDto request)
        {
            var pagedReports = await _reportService.GetAllProjectedWithPaginationAsync<ReportListDto, ReportSpecification>(request);
            var response = new ApiResponse<PagedCollection<ReportListDto>>(pagedReports);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ReportDetailDto>>> GetReport(int id)
        {
            var data = await _reportService.GetByIdProjectedAsync<ReportDetailDto>(id);
            var response = new ApiResponse<ReportDetailDto?>(data);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, UpdateReportDto request)
        {
            await _reportService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostReport(CreateReportDto report)
        {
            var newReport = await _reportService.CreateAsync(report);
            var response = new ApiResponse<Report>(newReport);
            return CreatedAtAction("GetReport", new { id = newReport.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReport(int id)
        {
            await _reportService.DeleteAsync(id);
            return NoContent();
        }
    }
}