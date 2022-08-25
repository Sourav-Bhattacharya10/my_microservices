using System;
using FluentValidation;

using employee_management.Application.DTOs.Employee;

namespace employee_management.Application.DTOs.Employee.Validators;

public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
{
    public UpdateEmployeeDtoValidator()
    {
    }
}