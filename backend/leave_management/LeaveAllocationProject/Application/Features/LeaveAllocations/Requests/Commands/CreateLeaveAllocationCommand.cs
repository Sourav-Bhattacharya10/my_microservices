using System;
using MediatR;

using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.Responses;

namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Commands;

public class CreateLeaveAllocationCommand: IRequest<ResultResponse<LeaveAllocationDto>>
{
    public CreateLeaveAllocationDto LeaveAllocationDto { get; set; } = default!;
}