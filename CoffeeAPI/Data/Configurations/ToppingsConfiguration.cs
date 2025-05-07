using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class ToppingsConfiguration : IEntityTypeConfiguration<Toppings>
    {
        public void Configure(EntityTypeBuilder<Toppings> builder)
        {
            builder.ToTable("Toppings");
            builder.HasKey(x => x.ToppingID);
            builder.Property(x => x.ToppingID).UseIdentityColumn();
        }
    }
}
