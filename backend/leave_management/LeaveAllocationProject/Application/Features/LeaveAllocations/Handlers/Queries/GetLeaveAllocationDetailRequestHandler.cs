using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using leave_management.LeaveAllocationProject.Domain;
using leave_management.LeaveAllocationProject.Application.DTOs.LeaveAllocation;
using leave_management.LeaveAllocationProject.Application.Responses;
using leave_management.LeaveAllocationProject.Application.Exceptions;
using leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Requests.Queries;
using leave_management.LeaveAllocationProject.Persistence.Contracts;
using leave_management.LeaveAllocationProject.Application.Enums;


namespace leave_management.LeaveAllocationProject.Application.Features.LeaveAllocations.Handlers.Queries;

public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, ResultResponse<LeaveAllocationDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveAllocationDto>> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveAllocationDto>();

        try
        {
            var leaveAllocation = await _unitOfWork.LeaveAllocationRepository.GetLeaveAllocationWithDetailsAsync(request.Id);

            if(leaveAllocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);

            var leaveAllocationDto = _mapper.Map<LeaveAllocationDto>(leaveAllocation);

            result = ResultResponse<LeaveAllocationDto>.Success(leaveAllocationDto, $"Fetch of {nameof(LeaveAllocation)} object successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveAllocation)} object failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveAllocationDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveAllocation)} object failed", ErrorType.Database, ex);
        }

        return result;
    }
}