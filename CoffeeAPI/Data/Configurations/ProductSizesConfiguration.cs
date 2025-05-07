using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ProductSizesConfiguration : IEntityTypeConfiguration<ProductSizes>
    {
        public void Configure(EntityTypeBuilder<ProductSizes> builder)
        {
            builder.ToTable("ProductSizes");
            builder.HasKey(x => x.ProductSizeID);
            builder.Property(x => x.ProductSizeID).UseIdentityColumn();
            builder.HasOne(x => x.Products).WithMany(x => x.ProductSizes).HasForeignKey(x => x.ProductID);
        }
    }
}
