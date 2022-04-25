using System;
using System.Collections.Generic;
using MediatR;

using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.Responses;

namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Queries;

public class GetLeaveAllocationListRequest : IRequest<ResultResponse<List<LeaveAllocationDto>>>
{

}