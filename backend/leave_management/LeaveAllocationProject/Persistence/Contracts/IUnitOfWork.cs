using System;
using System.Threading.Tasks;

using leave_management.LeaveAllocationProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveAllocationProject.Persistence.Contracts;

public interface IUnitOfWork : IDisposable
{
    ILeaveTypeRepository LeaveTypeRepository { get; }
    ILeaveAllocationRepository LeaveAllocationRepository { get; }

    Task SaveChangesAsync();
}