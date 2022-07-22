using employee_management.Application.DTOs.Common;

namespace employee_management.Application.DTOs.Employee;

public class EmployeeDto : BaseDto, IEmployeeDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public DateTime DateOfJoining { get; set; }
    public string ProfileImage { get; set; } = default!;
}