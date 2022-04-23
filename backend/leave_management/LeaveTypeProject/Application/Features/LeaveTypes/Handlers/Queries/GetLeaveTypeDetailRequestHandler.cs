using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using leave_management.LeaveTypeProject.Domain;
using leave_management.LeaveTypeProject.Application.DTOs.LeaveType;
using leave_management.LeaveTypeProject.Application.Responses;
using leave_management.LeaveTypeProject.Application.Exceptions;
using leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Requests.Queries;
using leave_management.LeaveTypeProject.Persistence.Contracts;
using leave_management.LeaveTypeProject.Application.Enums;


namespace leave_management.LeaveTypeProject.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, ResultResponse<LeaveTypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveTypeDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveTypeDto>> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveTypeDto>();

        try
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.GetAsync(request.Id);

            if(leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            var leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);

            result = ResultResponse<LeaveTypeDto>.Success(leaveTypeDto, $"Fetch of {nameof(LeaveType)} object successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<LeaveTypeDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveType)} object failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveTypeDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveType)} object failed", ErrorType.Database, ex);
        }

        return result;
    }
}