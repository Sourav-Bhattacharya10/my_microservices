using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using employee_management.Domain.Common;

namespace employee_management.Domain;

public class Employee : BaseDomainEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime DateOfJoining { get; set; }
    public string ProfileImage { get; set; } = default!;
}