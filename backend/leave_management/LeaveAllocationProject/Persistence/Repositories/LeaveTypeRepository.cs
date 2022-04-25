using leave_management.LeaveAllocationProject.Domain;
using leave_management.LeaveAllocationProject.Persistence;
using leave_management.LeaveAllocationProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveAllocationProject.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}