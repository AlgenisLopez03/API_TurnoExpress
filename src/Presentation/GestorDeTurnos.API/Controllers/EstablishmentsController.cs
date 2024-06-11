using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.Establishment;
using GestorDeTurnos.Application.Interfaces.Helpers;
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
        private readonly IFileManager<Establishment> _fileManager;

        public EstablishmentsController(ApplicationDbContext context, IEstablishmentService establishmentService, IFileManager<Establishment> fileManager)
        {
            _establishmentService = establishmentService;
            _fileManager = fileManager;
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

        [HttpPost]
        public async Task<ActionResult> PostEstablishment(CreateEstablishmentDto establishment)
        {
            var imageUrl = string.Empty;

            if (establishment.ImageFile != null)
            {
                imageUrl = await _fileManager.SaveAsync(establishment.ImageFile);
            }

            establishment.ProfileImage = imageUrl;

            var newEstablishment = await _establishmentService.CreateAsync(establishment);
            var response = new ApiResponse<Establishment>(newEstablishment);
            return CreatedAtAction("GetEstablishment", new { id = newEstablishment.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstablishment(int id, [FromForm] UpdateEstablishmentDto request)
        {
            if (request.ImageFile != null)
            {
                request.ProfileImage = await _fileManager.UpdateAsync(request.ImageFile, request.ProfileImage);
            }
            await _establishmentService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEstablishment(int id)
        {
            var establishment = await _establishmentService.GetByIdAsync(id);
            _fileManager.Delete(establishment.ProfileImage);

            await _establishmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}