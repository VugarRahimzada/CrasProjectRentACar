using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.BrandName)
           .IsRequired();

            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
