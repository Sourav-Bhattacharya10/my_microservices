using MediatR;

using leave_management.LeaveTypeProject.Application.Responses;
using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Commands;

public class DeleteLeaveTypeCommand : IRequest<ResultResponse<LeaveTypeDto>>
{
    public int Id { get; set; }
}