using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class Categories_MaterialConfiguration : IEntityTypeConfiguration<Categories_Material>
    {
        public void Configure(EntityTypeBuilder<Categories_Material> builder)
        {
            builder.ToTable("Categories_Material");
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryID).UseIdentityColumn();
        }
    }
}
