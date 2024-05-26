using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.DbContexts;

namespace GestorDeTurnos.Persistence.Repositories
{
    public class ReportRepository : RepositoryBase<Report>, IReportRepository
    {
        public ReportRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider)
            : base(context, configurationProvider)
        {
        }
    }
}