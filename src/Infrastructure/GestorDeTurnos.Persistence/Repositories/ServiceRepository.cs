using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider)
            : base(context, configurationProvider)
        {
        }
    }
}