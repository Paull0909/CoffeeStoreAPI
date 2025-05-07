using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class Categories_ProductConfiguration : IEntityTypeConfiguration<Categories_Products>
    {
        public void Configure(EntityTypeBuilder<Categories_Products> builder)
        {
            builder.ToTable("Categories_Product");
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryID).UseIdentityColumn();
        }
    }
}
