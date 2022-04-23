using leave_management.LeaveTypeProject.Domain;
using leave_management.LeaveTypeProject.Persistence;
using leave_management.LeaveTypeProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveTypeProject.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}