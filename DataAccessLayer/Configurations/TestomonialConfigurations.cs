using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class TestomonialConfigurations : IEntityTypeConfiguration<Testomonial>
    {
        public void Configure(EntityTypeBuilder<Testomonial> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.Position)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.LinkedIn)
              .IsRequired()
              .HasMaxLength(500);

            builder.Property(c => c.PhotoPath)
              .IsRequired()
              .HasMaxLength(500);



            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
