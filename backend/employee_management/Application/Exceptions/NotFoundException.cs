using System;

namespace employee_management.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
    {
        
    }
}