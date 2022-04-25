using System;

using leave_management.LeaveAllocationProject.Application.DTOs.Common;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;

public class LeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; } = default!;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }    
}