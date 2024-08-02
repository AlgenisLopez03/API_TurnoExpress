using Asp.Versioning;
using GestorDeTurnos.Application.Dtos.EstablishmentRole;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Pagination;
using GestorDeTurnos.Application.Specification;
using GestorDeTurnos.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestorDeTurnos.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class EstablishmentRolesController : ControllerBase
    {
        private readonly IEstablishmentRoleService _service;

        public EstablishmentRolesController(IEstablishmentRoleService service)
        {
            _service = service;
        }
        /// <summary>
        /// Retrieves all establishment roles with pagination and filtering options.
        /// </summary>
        /// <param name="request">The filter and pagination parameters for retrieving establishment roles.</param>
        /// <returns>An ApiResponse containing a paged collection of EstablishmentRoleListDto.</returns>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<EstablishmentRoleListDto>>>> GetAllRolesAsync([FromQuery] EstablishmentRoleFilterAndPaginationDto request)
        {
            var pagedRoles = await _service.GetAllProjectedWithPaginationAsync<EstablishmentRoleListDto, EstablishmentRoleSpecification>(request);
            var response = new ApiResponse<PagedCollection<EstablishmentRoleListDto>>(pagedRoles);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves the details of a specific establishment role based on its ID.
        /// </summary>
        /// <param name="id">The ID of the establishment role.</param>
        /// <returns>An ApiResponse containing the details of the establishment role as EstablishmentRoleDetailDto.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstablishmentRoleDetailDto>>> GetRole(int id)
        {
            var data = await _service.GetByIdProjectedAsync<EstablishmentRoleDetailDto>(id);
            var response = new ApiResponse<EstablishmentRoleDetailDto?>(data);
            return Ok(response);
        }
    }
}
