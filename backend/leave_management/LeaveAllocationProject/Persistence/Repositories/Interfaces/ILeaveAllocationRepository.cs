using System.Threading.Tasks;
using System.Collections.Generic;

using leave_management.LeaveAllocationProject.Domain;

namespace leave_management.LeaveAllocationProject.Persistence.Repositories.Interfaces;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task<LeaveAllocation?> GetLeaveAllocationWithDetailsAsync(int id);
    Task<IReadOnlyList<LeaveAllocation>> GetLeaveAllocationsWithDetailsAsync();
}