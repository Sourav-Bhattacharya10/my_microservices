using System;

namespace leave_management.LeaveAllocationProject.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
    {
        
    }
}