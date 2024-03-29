using System;

namespace employee_management.Application.DTOs.Employee;

public class UpdateEmployeeDto : IEmployeeDto
{
    public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    public string LastModifiedBy { get; set; } = "Sourav";
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfJoining { get; set; }
    public string ProfileImage { get; set; } = default!;
}