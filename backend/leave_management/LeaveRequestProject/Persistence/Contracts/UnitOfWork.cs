using System;
using System.Threading.Tasks;

using leave_management.LeaveRequestProject.Persistence;
using leave_management.LeaveRequestProject.Persistence.Repositories;
using leave_management.LeaveRequestProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveRequestProject.Persistence.Contracts;

public class UnitOfWork : IUnitOfWork
{
    private readonly LeaveManagementDbContext _context;

    private ILeaveTypeRepository _leaveTypeRepository = default!;
    private ILeaveRequestRepository _leaveRequestRepository = default!;

    public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_context);
    public ILeaveRequestRepository LeaveRequestRepository => _leaveRequestRepository ??= new LeaveRequestRepository(_context);

    public UnitOfWork(LeaveManagementDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}