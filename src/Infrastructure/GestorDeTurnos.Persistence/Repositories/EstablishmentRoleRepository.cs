
using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class EstablishmentRoleRepository : RepositoryBase<EstablishmentRoles>, IEstablishmentRoleRepository
    {
        public EstablishmentRoleRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider) : base(context, configurationProvider)
        {
        }
    }
}
