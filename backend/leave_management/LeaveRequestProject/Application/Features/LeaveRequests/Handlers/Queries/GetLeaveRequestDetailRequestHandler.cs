using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

using leave_management.LeaveRequestProject.Domain;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;
using leave_management.LeaveRequestProject.Application.Exceptions;
using leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Queries;
using leave_management.LeaveRequestProject.Persistence.Contracts;
using leave_management.LeaveRequestProject.Application.Enums;


namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Handlers.Queries;

public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, ResultResponse<LeaveRequestDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<LeaveRequestDto>> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<LeaveRequestDto>();

        try
        {
            var leaveRequest = await _unitOfWork.LeaveRequestRepository.GetLeaveRequestWithDetailsAsync(request.Id);

            if(leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest), request.Id);

            var leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequest);

            result = ResultResponse<LeaveRequestDto>.Success(leaveRequestDto, $"Fetch of {nameof(LeaveRequest)} object successful");
        }
        catch (NotFoundException ex)
        {
            result = ResultResponse<LeaveRequestDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveRequest)} object failed as the record was not found", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<LeaveRequestDto>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveRequest)} object failed", ErrorType.Database, ex);
        }

        return result;
    }
}