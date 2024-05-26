using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class EstablishmentRepository : RepositoryBase<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider)
            : base(context, configurationProvider)
        {
        }
    }
}