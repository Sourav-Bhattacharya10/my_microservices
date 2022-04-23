using System;
using MediatR;

using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.Responses;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Commands;

public class CreateLeaveTypeCommand: IRequest<ResultResponse<LeaveTypeDto>>
{
    public CreateLeaveTypeDto LeaveTypeDto { get; set; } = default!;
}