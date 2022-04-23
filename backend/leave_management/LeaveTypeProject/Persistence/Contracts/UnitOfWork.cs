using System;
using System.Threading.Tasks;

using leave_management.LeaveTypeProject.Persistence;
using leave_management.LeaveTypeProject.Persistence.Repositories;
using leave_management.LeaveTypeProject.Persistence.Repositories.Interfaces;

namespace leave_management.LeaveTypeProject.Persistence.Contracts;

public class UnitOfWork : IUnitOfWork
{
    private readonly LeaveManagementDbContext _context;

    private ILeaveTypeRepository _leaveTypeRepository = default!;
    

    public ILeaveTypeRepository LeaveTypeRepository => _leaveTypeRepository ??= new LeaveTypeRepository(_context);

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