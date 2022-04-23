namespace leave_management.LeaveTypeProject.Application.DTOs.LeaveType;

public interface ILeaveTypeDto
{
    string Name { get; set; }
    int DefaultDays { get; set; }
}