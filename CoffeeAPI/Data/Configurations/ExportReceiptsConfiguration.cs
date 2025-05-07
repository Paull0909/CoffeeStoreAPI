using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ExportReceiptsConfiguration : IEntityTypeConfiguration<ExportReceipts>
    {
        public void Configure(EntityTypeBuilder<ExportReceipts> builder)
        {
            builder.ToTable("ExportReceipts");
            builder.HasKey(x => x.ExportID);
            builder.Property(x => x.ExportID).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(x => x.ExportReceipts).HasForeignKey(x => x.UserID);
        }
    }
}
