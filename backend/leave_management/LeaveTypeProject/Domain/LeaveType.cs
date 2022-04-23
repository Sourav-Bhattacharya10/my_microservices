using System;

using leave_management.LeaveTypeProject.Domain.Common;

namespace leave_management.LeaveTypeProject.Domain;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = default!;
    public int DefaultDays { get; set; }
}