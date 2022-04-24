using leave_management.LeaveRequestProject.Application.DTOs.Common;

namespace leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;

public class ChangeLeaveRequestApprovalDto : BaseDto
{
    public bool? Approved { get; set; }
}