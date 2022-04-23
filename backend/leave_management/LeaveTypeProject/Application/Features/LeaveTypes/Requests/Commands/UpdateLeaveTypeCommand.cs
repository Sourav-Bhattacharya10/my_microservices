using MediatR;

using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.Responses;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Commands;

public class UpdateLeaveTypeCommand : IRequest<ResultResponse<LeaveTypeDto>>
{
    public LeaveTypeDto LeaveTypeDto { get; set; } = default!;
}