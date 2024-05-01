using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RendMyRide.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RendMyRide.DataAccess.Configurations
{
    internal class DriverConfigurations : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.ToTable(nameof(Driver));
            builder.HasKey(d => d.Id);

            builder.Property(d => d.FullName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(d => d.Age)
                .IsRequired();

            builder.Property(d => d.DriverLicenseNumber)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(d => d.Car)
                .WithOne(c => c.Driver)
                .HasForeignKey<Car>(d => d.DriverId);
        }
    }
}
