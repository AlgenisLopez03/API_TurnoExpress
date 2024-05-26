using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Establishment;
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
    public class EstablishmentsController : ControllerBase
    {
        private readonly IEstablishmentService _establishmentService;

        public EstablishmentsController(ApplicationDbContext context, IEstablishmentService establishmentService)
        {
            _establishmentService = establishmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<EstablishmentListDto>>>> GetAllEstablishmentsAsync([FromQuery] EstablishmentFilterAndPaginationDto request)
        {
            var pagedEstablishments = await _establishmentService.GetAllProjectedWithPaginationAsync<EstablishmentListDto, EstablishmentSpecification>(request);
            var response = new ApiResponse<PagedCollection<EstablishmentListDto>>(pagedEstablishments);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstablishmentDetailDto>>> GetEstablishment(int id)
        {
            var data = await _establishmentService.GetByIdProjectedAsync<EstablishmentDetailDto>(id);
            var response = new ApiResponse<EstablishmentDetailDto?>(data);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstablishment(int id, UpdateEstablishmentDto request)
        {
            await _establishmentService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> PostEstablishment(CreateEstablishmentDto establishment)
        {
            var newEstablishment = await _establishmentService.CreateAsync(establishment);
            var response = new ApiResponse<Establishment>(newEstablishment);
            return CreatedAtAction("GetEstablishment", new { id = newEstablishment.Id }, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstablishment(int id)
        {
            await _establishmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}