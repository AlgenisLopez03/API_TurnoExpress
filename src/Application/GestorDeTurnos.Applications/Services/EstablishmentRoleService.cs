
using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Services
{
    public class EstablishmentRoleService : ServiceBase<EstablishmentRoles>, IEstablishmentRoleService
    {
        public EstablishmentRoleService(IAsyncRepository<EstablishmentRoles> repository, IMapper mapper, IHttpContextAccessor httpContext) : base(repository, mapper, httpContext)
        {
        }
    }
}
