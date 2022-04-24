using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using leave_management.LeaveRequestProject.Domain;

namespace leave_management.LeaveRequestProject.Persistence.Configurations.Entities;

public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
{
    public void Configure(EntityTypeBuilder<LeaveRequest> builder)
    {

    }
}