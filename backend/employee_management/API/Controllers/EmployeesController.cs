using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using employee_management.Application.DTOs.Employee;
// using employee_management.Application.Features.Employees.Requests.Commands;
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

    // [HttpPost]
    // public async Task<IActionResult> CreateLeaveAllocation(CreateLeaveAllocationDto createLeaveAllocationDto)
    // {
    //     return HandleResult<LeaveAllocationDto>(await Mediator.Send(new CreateLeaveAllocationCommand{ LeaveAllocationDto = createLeaveAllocationDto }));
    // }

    // [HttpPut]
    // public async Task<IActionResult> UpdateLeaveAllocation(UpdateLeaveAllocationDto updateLeaveAllocationDto)
    // {
    //     return HandleResult<LeaveAllocationDto>(await Mediator.Send(new UpdateLeaveAllocationCommand{ LeaveAllocationDto = updateLeaveAllocationDto }));
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteLeaveAllocation(int id)
    // {
    //     return HandleResult<LeaveAllocationDto>(await Mediator.Send(new DeleteLeaveAllocationCommand{ Id = id }));
    // }
}