using AutoMapper;
using CoreDemo.Dto;
using CoreDemo.Models;

namespace CoreDemo
{
    public class AppMapperProfile:Profile
    {
        public AppMapperProfile()
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<DepartmentDto, Department>();
        }
    }
}
