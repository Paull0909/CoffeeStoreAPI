using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(x => x.SupplierID);
            builder.Property(x => x.SupplierID).UseIdentityColumn();
        }
    }
}
