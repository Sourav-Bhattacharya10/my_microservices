using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using leave_management.LeaveTypeProject.Domain;
using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.DTOs.LeaveType.Validators;
using leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Commands;
using leave_management.LeaveTypeProject.Application.Exceptions;
using leave_management.LeaveTypeProject.Application.Responses;
using leave_management.LeaveTypeProject.Persistence.Contracts;
using leave_management.LeaveTypeProject.Application.Enums;

namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Handlers.Commands;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, ResultResponse<LeaveTypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveTypeDto>> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveTypeDto>();

        try
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if(!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var leaveType = await _unitOfWork.LeaveTypeRepository.GetAsync(request.LeaveTypeDto.Id);

            if(leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            leaveType =  _unitOfWork.LeaveTypeRepository.Update(leaveType);

            await _unitOfWork.SaveChangesAsync();

            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);

            result = ResultResponse<LeaveTypeDto>.Success(leaveTypeDto, $"Updation of {nameof(LeaveType)} successful");
        }
        catch (ValidationException ex)
        {
            result = ResultResponse<LeaveTypeDto>.Failure(ex.Errors, $"Validation of {nameof(LeaveType)} updation failed", ErrorType.Validation);
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<LeaveTypeDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(LeaveType)} failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveTypeDto>.Failure(new List<string>() {ex.Message}, $"Updation of {nameof(LeaveType)} is failed", ErrorType.Database, ex);
        }

        return result;
    }
}