using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using employee_management.Domain;
using employee_management.Application.DTOs.Employee;
using employee_management.Application.DTOs.Employee.Validators;
using employee_management.Application.Features.Employees.Requests.Commands;
using employee_management.Application.Exceptions;
using employee_management.Application.Responses;
using employee_management.Persistence.Repositories.Interfaces;
using employee_management.Application.Enums;

namespace employee_management.Application.Features.Employees.Handlers.Commands;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand, ResultResponse<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public DeleteCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse<EmployeeDto>> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<EmployeeDto>();

        try
        {
            var employee = await _employeeRepository.GetAsync(request.Id);

            if(employee == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            var operationResult = await _employeeRepository.DeleteAsync(request.Id);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            result = ResultResponse<EmployeeDto>.Success(employeeDto, $"Delete of {nameof(Employee)} object successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Delete of {nameof(Employee)} object failed as the record was not found", ErrorType.NotFound);
        }
        catch (NullReferenceException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Delete of {nameof(Employee)} object failed as {ex.Message}", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Delete of {nameof(Employee)} object failed", ErrorType.Database, ex);
        }

        return result;
    }
}