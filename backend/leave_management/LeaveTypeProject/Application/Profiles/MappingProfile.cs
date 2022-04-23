using AutoMapper;

using leave_management.LeaveTypeProject.Domain;
using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveTypeProject.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
    }
}