using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using leave_management.LeaveRequestProject.Domain;
using leave_management.LeaveRequestProject.Persistence;
using leave_management.LeaveRequestProject.Persistence.Repositories;
using leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveRequestProject.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetailsAsync(int id)
    {
        try
        {
            var leaveRequest = await _dbContext.LeaveRequests
                                            .Include(q => q.LeaveType)
                                            .FirstOrDefaultAsync(q => q.Id == id);

            return leaveRequest;
        }
        catch
        {
            throw new NullReferenceException("no data found");
        }
    }

    public async Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsAsync()
    {
        try
        {
            var leaveRequests = await _dbContext.LeaveRequests
                                            .Include(q => q.LeaveType)
                                            .ToListAsync();

            return leaveRequests;
        }
        catch
        {
            throw new NullReferenceException("no data found");
        }
    }

    public LeaveRequest ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
    {
        leaveRequest.Approved = ApprovalStatus;
        _dbContext.Entry(leaveRequest).State = EntityState.Modified;

        return leaveRequest;
    }
}