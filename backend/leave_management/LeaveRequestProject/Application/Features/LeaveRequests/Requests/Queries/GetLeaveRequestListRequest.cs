using System;
using System.Collections.Generic;
using MediatR;

using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;

namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Queries;

public class GetLeaveRequestListRequest : IRequest<ResultResponse<List<LeaveRequestListDto>>>
{

}