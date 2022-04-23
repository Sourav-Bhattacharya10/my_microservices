using System;
using System.Threading.Tasks;

using leave_management.LeaveTypeProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveTypeProject.Persistence.Contracts;

public interface IUnitOfWork : IDisposable
{
    ILeaveTypeRepository LeaveTypeRepository { get; }
    Task SaveChangesAsync();
}