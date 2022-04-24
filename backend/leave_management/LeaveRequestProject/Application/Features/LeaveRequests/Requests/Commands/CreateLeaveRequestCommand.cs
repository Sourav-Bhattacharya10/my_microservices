using System;
using MediatR;

using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;

namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Commands;

public class CreateLeaveRequestCommand : IRequest<ResultResponse<LeaveRequestDto>>
{
    public CreateLeaveRequestDto LeaveRequestDto { get; set; } = default!;
}