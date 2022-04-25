using System;

namespace leave_management.LeaveAllocationProject.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}