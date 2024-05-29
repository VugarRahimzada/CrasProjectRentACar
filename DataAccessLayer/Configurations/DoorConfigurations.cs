using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class DoorConfigurations : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.DoorCount)
           .IsRequired();

            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
