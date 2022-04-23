using System;
using System.Collections.Generic;
using MediatR;

using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.Responses;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeListRequest : IRequest<ResultResponse<List<LeaveTypeDto>>>
{

}