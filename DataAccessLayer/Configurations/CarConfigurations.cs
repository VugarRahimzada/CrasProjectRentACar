using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class CarConfigurations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Seat)
                .IsRequired();

            builder.Property(c => c.Luggage)
                .IsRequired();

            builder.Property(c => c.Engine)
                .IsRequired();

            builder.Property(c => c.Year)
                .IsRequired();

            builder.Property(c => c.FuelEconomy)
                .IsRequired();

            builder.Property(c => c.Kilometer)
                .IsRequired();

            builder.Property(c => c.ExteriorColor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.InteriorColor)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(c => c.Brand)
                .WithMany(c=>c.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Body)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.BodyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Door)
               .WithMany(c => c.Cars)
                .HasForeignKey(c => c.DoorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Fuel)
               .WithMany(c => c.Cars)
                .HasForeignKey(c => c.FuelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Transmission)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.TransmissionId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasIndex(c => new { c.Id, c.Delete })
                   .IsUnique();
        }
    }
}
