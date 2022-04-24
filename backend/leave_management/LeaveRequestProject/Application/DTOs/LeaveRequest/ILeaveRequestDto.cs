using System;

using leave_management.LeaveRequestProject.Application.DTOs.Common;

namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

public interface ILeaveRequestDto
{
    DateTime StartDate { get; set; }
    DateTime EndDate { get; set; }
    int LeaveTypeId { get; set; }
}