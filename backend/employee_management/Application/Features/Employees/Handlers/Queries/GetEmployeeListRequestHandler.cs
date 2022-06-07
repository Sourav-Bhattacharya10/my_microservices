using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;

using employee_management.Domain;
using employee_management.Persistence.Repositories.Interfaces;
using employee_management.Application.DTOs.Employee;
using employee_management.Application.Features.Employees.Requests.Queries;
using employee_management.Application.Responses;
using employee_management.Application.Enums;

namespace employee_management.Application.Features.Employees.Handlers.Queries;

public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeeListRequest, ResultResponse<List<EmployeeDto>>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeListRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse<List<EmployeeDto>>> Handle(GetEmployeeListRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<List<EmployeeDto>>();

        try
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            result = ResultResponse<List<EmployeeDto>>.Success(employeesDto, $"Fetch of {nameof(Employee)} list successful");
        }
        catch (NullReferenceException ex)
        {
            result = ResultResponse<List<EmployeeDto>>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(Employee)} list failed as {ex.Message}", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<List<EmployeeDto>>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(Employee)} list failed", ErrorType.Database, ex);
        }

        return result;
    }
}