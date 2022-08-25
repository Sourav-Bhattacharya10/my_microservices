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

public class UpdateEmployeeCommandHandler: IRequestHandler<UpdateEmployeeCommand, ResultResponse<EmployeeDto>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<ResultResponse<EmployeeDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<EmployeeDto>();

        try
        {
            var employee = await _employeeRepository.GetAsync(request.Id);
            if(employee == null)
                throw new NotFoundException(nameof(Employee), request.Id);

            employee = _mapper.Map<Employee>(request.EmployeeDto);

            employee = await _employeeRepository.UpdateAsync(request.Id, employee);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            result = ResultResponse<EmployeeDto>.Success(employeeDto, $"Updation of {nameof(Employee)} successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(Employee)} failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<EmployeeDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(Employee)} failed", ErrorType.Database, ex);
        }

        return result;
    }
}