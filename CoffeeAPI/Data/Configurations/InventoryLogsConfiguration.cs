using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class InventoryLogsConfiguration : IEntityTypeConfiguration<InventoryLogs>
    {
        public void Configure(EntityTypeBuilder<InventoryLogs> builder)
        {
            builder.ToTable("InventoryLogs");
            builder.HasKey(x => x.InventoryLogID);
            builder.Property(x => x.InventoryLogID).UseIdentityColumn();
            builder.HasOne(x => x.Materials).WithMany(x => x.InventoryLogs).HasForeignKey(x => x.MaterialID);

        }
    }
}
