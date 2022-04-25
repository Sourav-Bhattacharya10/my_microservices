using FluentValidation;

using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation.Validators;

public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));
    }
}