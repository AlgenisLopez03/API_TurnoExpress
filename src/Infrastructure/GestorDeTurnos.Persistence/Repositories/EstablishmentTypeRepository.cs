
using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class EstablishmentTypeRepository : RepositoryBase<EstablishmentTypes>, IEstablishmentTypeRepository
    {
        public EstablishmentTypeRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider) : base(context, configurationProvider)
        {
        }
    }
}
