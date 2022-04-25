using System;
using MediatR;

using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.Responses;

namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Queries;

public class GetLeaveAllocationDetailRequest : IRequest<ResultResponse<LeaveAllocationDto>>
{
    public int Id { get; set; }
}