using AutoMapper;
using MVCDefaultProject.Controllers;
using MVCDefaultProject.Dto;
using MVCDefaultProject.Models;

namespace MVCDefaultProject.Mapper
{
    public class EmployeeProfile  : Profile
    {
        public EmployeeProfile() {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        
        }
    }
}
