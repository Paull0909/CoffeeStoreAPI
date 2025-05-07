using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class RecipesConfiguration : IEntityTypeConfiguration<Recipes>
    {
        public void Configure(EntityTypeBuilder<Recipes> builder)
        {
            builder.ToTable("Recipes");
            builder.HasKey(x => x.RecipeID);
            builder.Property(x => x.RecipeID).UseIdentityColumn();
            builder.HasOne(x => x.ProductSizes).WithOne(x => x.Recipes).HasForeignKey<Recipes>(x => x.ProductSizeID);
            builder.HasOne(x => x.Materials).WithMany(x => x.Recipes).HasForeignKey(x => x.MaterialID);
        }
    }
}
