using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using leave_management.LeaveAllocationProject.Domain;

namespace leave_management.LeaveAllocationProject.Persistence.Configurations.Entities;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
    {

    }
}