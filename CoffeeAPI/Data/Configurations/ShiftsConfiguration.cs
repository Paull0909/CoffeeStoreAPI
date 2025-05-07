using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ShiftsConfiguration : IEntityTypeConfiguration<Shifts>
    {
        public void Configure(EntityTypeBuilder<Shifts> builder)
        {
            builder.ToTable("Shifts");
            builder.HasKey(x => x.ShiftID);
            builder.Property(x => x.ShiftID).UseIdentityColumn();
        }
    }
}
