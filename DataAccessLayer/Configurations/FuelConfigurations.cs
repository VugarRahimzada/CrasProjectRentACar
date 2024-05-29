using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class FuelConfigurations : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Type)
           .IsRequired();

            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
