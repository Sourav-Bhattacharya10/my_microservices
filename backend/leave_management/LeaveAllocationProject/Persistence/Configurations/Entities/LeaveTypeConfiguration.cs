using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using leave_management.LeaveAllocationProject.Domain;

namespace leave_management.LeaveAllocationProject.Persistence.Configurations.Entities;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        
    }
}