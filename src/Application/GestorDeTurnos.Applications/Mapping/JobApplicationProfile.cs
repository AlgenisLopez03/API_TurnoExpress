
using AutoMapper;
using GestorDeTurnos.Application.Dtos.JobApplication;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile() 
        {
            CreateMap<CreateJobApplicationDto, JobApplication>();
            CreateMap<UpdateJobApplicationDto, JobApplication>();

            CreateMap<JobApplication, JobApplicationListDto>();
            CreateMap<JobApplication, JobApplicationDetailDto>();
        }
    }
}
