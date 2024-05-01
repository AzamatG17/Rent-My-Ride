using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RendMyRide.Domain.Models;

namespace RendMyRide.DataAccess.Configurations
{
    internal class CarConfigurations : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable(nameof(Car));
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Model)
                .IsRequired();
            builder.Property(c => c.Brand)
                .IsRequired();
            builder.Property(c => c.Year)
                .IsRequired();
            builder.Property(c => c.PricePerHour)
                .IsRequired();
            builder.Property(c => c.RentStartTime)
                .IsRequired();
            builder.Property(c => c.RentEndTime)
                .IsRequired();
            builder.Property(c => c.AvailableForRent)
                .IsRequired();

            builder.HasOne(c => c.Driver)
                .WithOne(d => d.Car)
                .HasForeignKey<Car>(c => c.DriverId);
        }
    }
}
