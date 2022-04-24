using System;
using System.Threading.Tasks;

using leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveRequestProject.Persistence.Contracts;

public interface IUnitOfWork : IDisposable
{
    ILeaveTypeRepository LeaveTypeRepository { get; }
    ILeaveRequestRepository LeaveRequestRepository { get; }

    Task SaveChangesAsync();
}