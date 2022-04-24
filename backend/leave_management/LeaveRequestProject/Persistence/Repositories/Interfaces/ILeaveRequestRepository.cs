using System.Threading.Tasks;
using System.Collections.Generic;

using leave_management.LeaveRequestProject.Domain;

namespace leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest?> GetLeaveRequestWithDetailsAsync(int id);
    Task<IReadOnlyList<LeaveRequest>> GetLeaveRequestsWithDetailsAsync();
    LeaveRequest ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
}