using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ImportDetailsConfiguration : IEntityTypeConfiguration<ImportDetails>
    {
        public void Configure(EntityTypeBuilder<ImportDetails> builder)
        {
            builder.ToTable("ImportDetails");
            builder.HasKey(x => x.ImportDetailID);
            builder.Property(x => x.ImportDetailID).UseIdentityColumn();
            builder.HasOne(x => x.ImportReceipts).WithMany(x => x.ImportDetails).HasForeignKey(x => x.ImportID).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Materials).WithMany(x => x.ImportDetails).HasForeignKey(x => x.MaterialID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
