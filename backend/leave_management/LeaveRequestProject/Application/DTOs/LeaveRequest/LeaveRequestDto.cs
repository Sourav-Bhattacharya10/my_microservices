using System;

using leave_management.LeaveRequestProject.Application.DTOs.Common;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = default!;
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; } = default!;
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}