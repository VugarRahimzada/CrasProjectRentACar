using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class BodyConfigurations : IEntityTypeConfiguration<Body>
    {
        public void Configure(EntityTypeBuilder<Body> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Type)
                .IsRequired();


            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
