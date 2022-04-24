namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveType;

public interface ILeaveTypeDto
{
    string Name { get; set; }
    int DefaultDays { get; set; }
}