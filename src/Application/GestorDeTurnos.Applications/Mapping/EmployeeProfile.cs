
using AutoMapper;
using GestorDeTurnos.Application.Dtos.Employee;
using GestorDeTurnos.Domain.Entities;

namespace GestorDeTurnos.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<CreateEmployeeDto, Employees>();
            CreateMap<UpdateEmployeeDto, Employees>();
            CreateMap<Employees, EmployeeDetailDto>();
            CreateMap<Employees, EmployeeListDto>();
        }
    }
}
