using System;

namespace leave_management.LeaveRequestProject.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
    {
        
    }
}