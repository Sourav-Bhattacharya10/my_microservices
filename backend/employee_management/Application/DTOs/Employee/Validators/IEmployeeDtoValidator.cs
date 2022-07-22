using System;
using FluentValidation;

using employee_management.Application.DTOs.Employee;

namespace employee_management.Application.DTOs.Employee.Validators;

public class IEmployeeDtoValidator : AbstractValidator<IEmployeeDto>
{

    public IEmployeeDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .EmailAddress();

        RuleFor(p => p.DateOfJoining)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();

        RuleFor(p => p.ProfileImage)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull();
    }
}