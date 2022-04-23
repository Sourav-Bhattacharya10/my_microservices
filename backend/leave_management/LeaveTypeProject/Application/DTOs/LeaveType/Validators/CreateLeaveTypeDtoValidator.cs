using FluentValidation;

using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;

namespace leave_management.LeaveTypeProject.Application.DTOs.LeaveType.Validators;

public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
{
    public CreateLeaveTypeDtoValidator()
    {
        Include(new ILeaveTypeDtoValidator());

        RuleFor(p => p.CreatedBy)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

        RuleFor(p => p.LastModifiedBy)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");
    }
}