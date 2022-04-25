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

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, ResultResponse<LeaveAllocationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveAllocationDto>> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveAllocationDto>();

        try
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_unitOfWork.LeaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

            if(!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetAsync(request.LeaveAllocationDto.Id);

            if(leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.LeaveAllocationDto.Id);

            _mapper.Map(request.LeaveAllocationDto, leaveAllocation);

            leaveAllocation = _unitOfWork.LeaveAllocationRepository.Update(leaveAllocation);

            await _unitOfWork.SaveChangesAsync();

            var leaveAllocationDto = _mapper.Map<LeaveAllocationDto>(leaveAllocation);

            result = ResultResponse<LeaveAllocationDto>.Success(leaveAllocationDto, $"Updation of {nameof(LeaveAllocation)} successful");
        }
        catch (ValidationException ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(ex.Errors, $"Validation of {nameof(LeaveAllocation)} updation failed", ErrorType.Validation);
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(LeaveAllocation)} failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(LeaveAllocation)} is failed", ErrorType.Database, ex);
        }

        return result;
    }
}