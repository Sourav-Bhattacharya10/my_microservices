using System;
using MediatR;

using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.Responses;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Queries;

public class GetLeaveTypeDetailRequest : IRequest<ResultResponse<LeaveTypeDto>>
{
    public int Id { get; set; }
}