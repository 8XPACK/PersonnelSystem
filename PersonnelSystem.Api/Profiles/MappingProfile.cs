using AutoMapper;
using PersonnelSystem.Application.Objects;
using PersonnelSystem.Core.Entities;

namespace PersonnelSystem.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<DepartmentDto, Department>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ParentId, y => y.Ignore())
                .ForMember(x => x.DateOfCreation, y => y.Ignore());
            CreateMap<Department, DepartmentDto>();

            CreateMap<UserDto, User>()
                .ForMember(x => x.Id, y => y.Ignore());
            CreateMap<User, UserDto>();

            CreateMap<EmployeeDto, Employee>()
                .ForMember(x => x.DateOfEmployment, y => y.Ignore());
            CreateMap<Employee, EmployeeDto>();


        }
    }
}
