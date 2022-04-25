namespace leave_management.LeaveAllocationProject.Application.DTOs.LeaveType;

public interface ILeaveTypeDto
{
    string Name { get; set; }
    int DefaultDays { get; set; }
}