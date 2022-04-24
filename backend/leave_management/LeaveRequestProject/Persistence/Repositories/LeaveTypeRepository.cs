using leave_management.LeaveRequestProject.Domain;
using leave_management.LeaveRequestProject.Persistence;
using leave_management.LeaveRequestProject.Persistence.Repositories;
using leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveRequestProject.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    private readonly LeaveManagementDbContext _dbContext;

    public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}