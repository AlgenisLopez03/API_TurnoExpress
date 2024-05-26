using AutoMapper;
using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace GestorDeTurnos.Application.Services
{
    public class ReportService : ServiceBase<Report>, IReportService
    {
        public ReportService(IAsyncRepository<Report> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(repository, mapper, httpContextAccessor)
        {
        }
    }
}