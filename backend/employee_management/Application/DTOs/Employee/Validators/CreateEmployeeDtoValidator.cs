using System;
using FluentValidation;

using employee_management.Application.DTOs.Employee;

namespace employee_management.Application.DTOs.Employee.Validators;

public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
{
    public CreateEmployeeDtoValidator()
    {
        Include(new IEmployeeDtoValidator());
    }
}