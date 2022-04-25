using System;

using leave_management.LeaveAllocationProject.Domain.Common;

namespace leave_management.LeaveAllocationProject.Domain;

public class LeaveAllocation : BaseDomainEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; } = default!;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}