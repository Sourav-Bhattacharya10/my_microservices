using MediatR;

using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;

namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Commands;

public class UpdateLeaveRequestCommand : IRequest<ResultResponse<LeaveRequestDto>>
{
    public int Id { get; set; }
    public UpdateLeaveRequestDto LeaveRequestDto { get; set; } = default!;

    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; } = default!;
}