using System;
using MediatR;

using employee_management.Application.DTOs.Employee;
using employee_management.Application.Responses;

namespace employee_management.Application.Features.Employees.Requests.Commands;

public class UpdateEmployeeCommand: IRequest<ResultResponse<EmployeeDto>>
{
    public string Id { get; set; } = default!;
    public UpdateEmployeeDto EmployeeDto { get; set; } = default!;
}