using System;
using MediatR;

using employee_management.Application.DTOs.Employee;
using employee_management.Application.Responses;

namespace employee_management.Application.Features.Employees.Requests.Commands;

public class CreateEmployeeCommand: IRequest<ResultResponse<EmployeeDto>>
{
    public CreateEmployeeDto EmployeeDto { get; set; } = default!;
}