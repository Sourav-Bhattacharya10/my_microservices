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

public class CreateEmployeeCommandHandler: IRequestHandler<CreateEmployeeCommand, ResultResponse<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<EmployeeDto>();

        try
        {
            var validator = new CreateEmployeeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto);

            if(!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var employee = _mapper.Map<Employee>(request.EmployeeDto);

            employee = await _employeeRepository.AddAsync(employee);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            result = ResultResponse<EmployeeDto>.Success(employeeDto, $"Creation of {nameof(Employee)} successful");
        }
        catch (ValidationException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(ex.Errors, $"Validation of {nameof(Employee)} creation failed", ErrorType.Validation);
        }
        catch (Exception ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Creation of {nameof(Employee)} failed", ErrorType.Database, ex);
        }

        return result;
    }
}