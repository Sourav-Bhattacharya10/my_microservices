using System;
using MediatR;

using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;

namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Queries;

public class GetLeaveRequestDetailRequest : IRequest<ResultResponse<LeaveRequestDto>>
{
    public int Id { get; set; }
}