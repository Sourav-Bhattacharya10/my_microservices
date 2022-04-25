using System;

using leave_management.LeaveAllocationProject.Domain.Common;

namespace leave_management.LeaveAllocationProject.Domain;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = default!;
    public int DefaultDays { get; set; }
}