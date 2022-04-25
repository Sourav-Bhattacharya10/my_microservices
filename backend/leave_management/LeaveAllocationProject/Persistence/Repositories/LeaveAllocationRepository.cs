using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using leave_management.LeaveAllocationProject.Domain;
using leave_management.LeaveAllocationProject.Persistence;
using leave_management.LeaveAllocationProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveAllocationProject.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetailsAsync(int id)
    {
        try
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                                            .Include(q => q.LeaveType)
                                            .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }
        catch
        {
            throw new NullReferenceException("no data found");
        }
    }

    public async Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync()
    {
        try
        {
            var leaveAllocations = await _dbContext.LeaveAllocations
                                            .Include(q => q.LeaveType)
                                            .ToListAsync();

            return leaveAllocations;
        }
        catch
        {
            throw new NullReferenceException("no data found");
        }
    }
}