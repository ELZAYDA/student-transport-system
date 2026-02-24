using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.PlateNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(v => v.PlateNumber)
                   .IsUnique()
                   .HasDatabaseName("IX_Vehicles_PlateNumber");
            
            builder.Property(v => v.Type)
            .IsRequired()
            .HasConversion<string>();

            builder.Property(v => v.Capacity)
                .IsRequired();

            builder.Property(v => v.IsActive)
                .HasDefaultValue(true);

            // العلاقة مع Driver
            builder.HasOne(v => v.Driver)
                .WithOne(d => d.Vehicle)
                .HasForeignKey<Vehicle>(v => v.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
