using System;
using System.Collections.Generic;
using MediatR;

using employee_management.Application.DTOs.Employee;
using employee_management.Application.Responses;

namespace employee_management.Application.Features.Employees.Requests.Queries;

public class GetEmployeeListRequest : IRequest<ResultResponse<List<EmployeeDto>>>
{

}