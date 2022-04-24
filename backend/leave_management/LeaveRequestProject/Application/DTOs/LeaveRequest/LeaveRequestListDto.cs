using System;

using leave_management.LeaveRequestProject.Application.DTOs.Common;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

public class LeaveRequestListDto : BaseDto
{
    public LeaveTypeDto LeaveType { get; set; } = default!;
    public DateTime DateRequested { get; set; }
    public bool? Approved { get; set; }
}