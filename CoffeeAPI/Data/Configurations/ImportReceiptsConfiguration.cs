using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ImportReceiptsConfiguration : IEntityTypeConfiguration<ImportReceipts>
    {
        public void Configure(EntityTypeBuilder<ImportReceipts> builder)
        {
            builder.ToTable("ImportReceipts");
            builder.HasKey(x => x.ImportID);
            builder.Property(x => x.ImportID).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(x => x.ImportReceipts).HasForeignKey(x => x.UserID);
            builder.HasOne(x => x.Suppliers).WithMany(x => x.ImportReceipts).HasForeignKey(x => x.SupplierID);
        }
    }
}
