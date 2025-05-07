using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.PaymentID);
            builder.Property(x => x.PaymentID).UseIdentityColumn();
        }
    }
}
