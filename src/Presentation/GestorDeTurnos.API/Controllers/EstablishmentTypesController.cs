using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.EstablishmentType;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Application.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EstablishmentTypesController : ControllerBase
    {
        private readonly IEstablishmentTypeService _service;

        public EstablishmentTypesController(IEstablishmentTypeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves all establishment types with pagination and filtering options.
        /// </summary>
        /// <param name="request">The filter and pagination parameters for retrieving establishment types.</param>
        /// <returns>An ApiResponse containing a paged collection of EstablishmentTypeListDto.</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<EstablishmentTypeListDto>>>> GetAllEstablishmentsAsync([FromQuery] EstablishmentTypeFilterAndPaginationDto request)
        {
            var pagedEstablishments = await _service.GetAllProjectedWithPaginationAsync<EstablishmentTypeListDto, EstablishmentTypeSpecification>(request);
            var response = new ApiResponse<PagedCollection<EstablishmentTypeListDto>>(pagedEstablishments);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves the details of a specific establishment type based on its ID.
        /// </summary>
        /// <param name="id">The ID of the establishment type.</param>
        /// <returns>An ApiResponse containing the details of the establishment type as EstablishmentTypeDetailDto.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstablishmentTypeDetailDto>>> GetEstablishment(int id)
        {
            var data = await _service.GetByIdProjectedAsync<EstablishmentTypeDetailDto>(id);
            var response = new ApiResponse<EstablishmentTypeDetailDto?>(data);
            return Ok(response);
        }

    }
}
