using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;

using leave_management.LeaveRequestProject.Domain;
using leave_management.LeaveRequestProject.Application.DTOs.LeaveRequest;
using leave_management.LeaveRequestProject.Application.Responses;
using leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Requests.Queries;
using leave_management.LeaveRequestProject.Persistence.Contracts;
using leave_management.LeaveRequestProject.Application.Enums;


namespace leave_management.LeaveRequestProject.Application.Features.LeaveRequests.Handlers.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, ResultResponse<List<LeaveRequestListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetLeaveRequestListRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultResponse<List<LeaveRequestListDto>>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var result = new ResultResponse<List<LeaveRequestListDto>>();

        try
        {
            var leaveRequests = await _unitOfWork.LeaveRequestRepository.GetLeaveRequestsWithDetailsAsync();
            var leaveRequestsDto = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);

            result = ResultResponse<List<LeaveRequestListDto>>.Success(leaveRequestsDto, $"Fetch of {nameof(LeaveRequest)} list successful");
        }
        catch (NullReferenceException ex)
        {
            result = ResultResponse<List<LeaveRequestListDto>>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveRequest)} list failed as {ex.Message}", ErrorType.NotFound);
        }
        catch (Exception ex)
        {
            result = ResultResponse<List<LeaveRequestListDto>>.Failure(new List<string>() {ex.Message}, $"Fetch of {nameof(LeaveRequest)} list failed", ErrorType.Database, ex);
        }

        return result;
    }
}