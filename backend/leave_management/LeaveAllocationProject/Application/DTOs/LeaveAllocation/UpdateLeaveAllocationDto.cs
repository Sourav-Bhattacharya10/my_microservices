using leave_management.LeaveAllocationProject.Application.DTOs.Common;

namespace leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;

public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }  
}