using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class AboutConfigurations : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
