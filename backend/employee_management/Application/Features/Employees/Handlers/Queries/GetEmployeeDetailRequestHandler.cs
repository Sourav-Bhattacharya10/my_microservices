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
using employee_management.Application.Exceptions;

namespace employee_management.Application.Features.Employees.Handlers.Queries;

public class GetEmployeeDetailRequestHandler : IRequestHandler<GetEmployeeDetailRequest, ResultResponse<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public GetEmployeeDetailRequestHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse<EmployeeDto>> Handle(GetEmployeeDetailRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<EmployeeDto>();

        try
        {
            var employee = await _employeeRepository.GetAsync(request.Id);
            if(employee == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            result = ResultResponse<EmployeeDto>.Success(employeeDto, $"Fetch of {nameof(Employee)} object successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(Employee)} object failed as the record was not found", ErrorType.NotFound);
        }
        catch (NullReferenceException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(Employee)} object failed as {ex.Message}", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(Employee)} object failed", ErrorType.Database, ex);
        }

        return result;
    }
}