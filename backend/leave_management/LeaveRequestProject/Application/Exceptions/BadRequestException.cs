using System;

namespace leave_management.LeaveRequestProject.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}