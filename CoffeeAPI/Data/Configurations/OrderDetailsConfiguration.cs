using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.OrderDetailID);
            builder.Property(x => x.OrderDetailID).UseIdentityColumn();
            builder.HasOne(x => x.Orders).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderID);
            builder.HasOne(x => x.Products).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID);
        }
    }
}
