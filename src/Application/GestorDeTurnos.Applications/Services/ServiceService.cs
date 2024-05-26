using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Services
{
    public class ServiceService : ServiceBase<Service>, IServiceService
    {
        public ServiceService(IAsyncRepository<Service> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(repository, mapper, httpContextAccessor)
        {
        }
    }
}