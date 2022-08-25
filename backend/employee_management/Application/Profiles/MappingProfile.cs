using AutoMapper;

using employee_management.Domain;
using employee_management.Application.DTOs.Employee;

namespace employee_management.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
        // CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        // CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        // CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
    }
}