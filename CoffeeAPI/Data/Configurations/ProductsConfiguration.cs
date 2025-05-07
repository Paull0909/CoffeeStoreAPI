using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductID).UseIdentityColumn();
            builder.HasOne(x => x.categories).WithMany(x => x.Products).HasForeignKey(x => x.CategoryID);
        }
    }
}
