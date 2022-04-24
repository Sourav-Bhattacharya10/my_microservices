using System;

using leave_management.LeaveRequestProject.Application.DTOs.Common;

namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

public class UpdateLeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComments { get; set; } = default!;
    public bool Cancelled { get; set; }
}