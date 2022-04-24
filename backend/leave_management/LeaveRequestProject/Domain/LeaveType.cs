using System;

using leave_management.LeaveRequestProject.Domain.Common;

namespace leave_management.LeaveRequestProject.Domain;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; } = default!;
    public int DefaultDays { get; set; }
}