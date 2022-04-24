using AutoMapper;

using leave_management.LeaveRequestProject.Domain;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveType;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

namespace leave_management.LeaveRequestProject.Application.Profiles;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();

        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
    }
}