using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using leave_management.LeaveAllocationProject.Domain;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation.Validators;
using leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Commands;
using leave_management.LeaveAllocationProject.Application.Exceptions;
using leave_management.LeaveAllocationProject.Application.Responses;
using leave_management.LeaveAllocationProject.Persistence.Contracts;
using leave_management.LeaveAllocationProject.Application.Enums;

namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler: IRequestHandler<CreateLeaveAllocationCommand, ResultResponse<LeaveAllocationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveAllocationDto>> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveAllocationDto>();

        try
        {
            var validator = new CreateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if(!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

            leaveAllocation = await _unitOfWork.LeaveAllocationRepository.AddAsync(leaveAllocation);

            await _unitOfWork.SaveChangesAsync();

            var leaveAllocationDto = _mapper.Map<LeaveAllocationDto>(leaveAllocation);

            result = ResultResponse<LeaveAllocationDto>.Success(leaveAllocationDto, $"Creation of {nameof(LeaveAllocation)} successful");
        }
        catch (ValidationException ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(ex.Errors, $"Validation of {nameof(LeaveAllocation)} creation failed", ErrorType.Validation);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(new List<string>() {ex.Message}, $"Creation of {nameof(LeaveAllocation)} failed", ErrorType.Database, ex);
        }

        return result;
    }
}