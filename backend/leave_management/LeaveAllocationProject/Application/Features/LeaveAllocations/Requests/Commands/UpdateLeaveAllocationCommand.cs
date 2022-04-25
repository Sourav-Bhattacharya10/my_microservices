using MediatR;

using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.Responses;

namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Commands;

public class UpdateLeaveAllocationCommand : IRequest<ResultResponse<LeaveAllocationDto>>
{
    public UpdateLeaveAllocationDto LeaveAllocationDto { get; set; } = default!;
}