using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class EmployeeSchedulesConfiguration : IEntityTypeConfiguration<EmployeeSchedules>
    {
        public void Configure(EntityTypeBuilder<EmployeeSchedules> builder)
        {
            builder.ToTable("EmployeeSchedules");
            builder.HasKey(x => x.ScheduleID);
            builder.Property(x => x.ScheduleID).UseIdentityColumn();
            builder.HasOne(x => x.Employees).WithMany(x => x.EmployeeSchedules).HasForeignKey(x => x.EmployeeID);
            builder.HasOne(x => x.Shifts).WithMany(x => x.EmployeeSchedules).HasForeignKey(x => x.ShiftID);
        }
    }
}
