using EntityLayer.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations
{
    public class BookingConfigurations : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Request)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(c => c.PickUpLocation)
               .IsRequired()
               .HasMaxLength(750);
            builder.Property(c => c.Destination)
             .IsRequired()
             .HasMaxLength(750);

            builder.Property(x => x.ReturnDate)
                .IsRequired();

            builder.Property(x => x.PickUpDate)
                .IsRequired();

            builder.HasOne(x => x.Car)
                .WithMany(x=>x.Bookings)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.Id, x.Delete })
                   .IsUnique();
        }
    }
}
