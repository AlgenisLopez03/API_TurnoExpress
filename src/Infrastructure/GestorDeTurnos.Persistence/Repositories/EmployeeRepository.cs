
using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employees>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider) : base(context, configurationProvider)
        {
        }
    }
}
