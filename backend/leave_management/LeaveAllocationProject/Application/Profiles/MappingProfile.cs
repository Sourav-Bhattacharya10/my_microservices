using AutoMapper;

using leave_management.LeaveAllocationProject.Domain;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveType;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;

namespace leave_management.LeaveAllocationProject.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();

        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
    }
}