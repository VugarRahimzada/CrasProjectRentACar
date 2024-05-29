using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class TransmissionConfigurations : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Type)
           .IsRequired();

            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
