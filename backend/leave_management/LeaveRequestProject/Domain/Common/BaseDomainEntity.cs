using System;

namespace leave_management.LeaveRequestProject.Domain.Common;

public abstract class BaseDomainEntity
{
    public int Id { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = default!;
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = default!;
}