using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class TimekeepingConfiguration : IEntityTypeConfiguration<Timekeeping>
    {
        public void Configure(EntityTypeBuilder<Timekeeping> builder)
        {
            builder.ToTable("Timekeeping");
            builder.HasKey(x => x.TimekeepingID);
            builder.Property(x => x.TimekeepingID).UseIdentityColumn();
            builder.HasOne(x => x.Employees).WithMany(x => x.Timekeepings).HasForeignKey(x => x.EmployeeID);
        }
    }
}
