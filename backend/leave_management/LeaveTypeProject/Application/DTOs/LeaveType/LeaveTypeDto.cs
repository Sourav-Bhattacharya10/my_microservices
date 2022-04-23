using leave_management.LeaveTypeProject.Application.DTOs.Common;

namespace leave_management.LeaveTypeProject.Application.DTOs.LeaveType;

public class LeaveTypeDto : BaseDto, ILeaveTypeDto
{
    public string Name { get; set; } = default!;
    public int DefaultDays { get; set; }
}