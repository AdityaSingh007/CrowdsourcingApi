using AutoMapper;
using SampleMinimalApi.EfCore.Entity;
using SampleMinimalApi.Model;

namespace SampleMinimalApi.AutomapperProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
