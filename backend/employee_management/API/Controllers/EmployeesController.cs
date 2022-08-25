using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using employee_management.Application.DTOs.Employee;
using employee_management.Application.Features.Employees.Requests.Commands;
using employee_management.Application.Features.Employees.Requests.Queries;

namespace employee_management.API.Controllers;

public class EmployeesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetEmployeeList()
    {
        return HandleResult<List<EmployeeDto>>(await Mediator.Send(new GetEmployeeListRequest()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeDetail(string id)
    {
        return HandleResult<EmployeeDto>(await Mediator.Send(new GetEmployeeDetailRequest{ Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {
        return HandleResult<EmployeeDto>(await Mediator.Send(new CreateEmployeeCommand{ EmployeeDto = createEmployeeDto }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(string id, UpdateEmployeeDto updateEmployeeDto)
    {
        return HandleResult<EmployeeDto>(await Mediator.Send(new UpdateEmployeeCommand{ Id = id, EmployeeDto = updateEmployeeDto }));
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteLeaveAllocation(int id)
    // {
    //     return HandleResult<LeaveAllocationDto>(await Mediator.Send(new DeleteLeaveAllocationCommand{ Id = id }));
    // }
}