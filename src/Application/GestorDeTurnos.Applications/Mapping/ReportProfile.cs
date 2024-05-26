using AutoMapper;
using GestorDeTurnos.Application.Dtos.Report;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<CreateReportDto, Report>();
            CreateMap<UpdateReportDto, Report>();
            CreateMap<Report, ReportListDto>();
            CreateMap<Report, ReportDetailDto>();
        }
    }
}