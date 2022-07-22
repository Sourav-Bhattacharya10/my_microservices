using System;

namespace employee_management.Application.DTOs.Employee;

public interface IEmployeeDto
{
    string Name { get; set; }
    string Email { get; set; }
    DateTime DateOfJoining { get; set; }
    string ProfileImage { get; set; }
}