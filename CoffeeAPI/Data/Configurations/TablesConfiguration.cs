using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    class TablesConfiguration : IEntityTypeConfiguration<Tables>
    {
        public void Configure(EntityTypeBuilder<Tables> builder)
        {
            builder.ToTable("Tables");
            builder.HasKey(x => x.TableID);
            builder.Property(x => x.TableID).UseIdentityColumn();
        }
    }
}
