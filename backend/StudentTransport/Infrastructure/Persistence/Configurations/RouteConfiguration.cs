using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Routes");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.StartPoint)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.EndPoint)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.DepartureTime)
                .IsRequired();

            builder.Property(r => r.Capacity)
                .IsRequired();

            builder.Property(r => r.CurrentOccupancy)
                .HasDefaultValue(0);

            // تحويل Enum
            var converter = new ValueConverter<RouteStatus, string>(
                v => v.ToString(),
                v => (RouteStatus)Enum.Parse(typeof(RouteStatus), v));

            builder.Property(r => r.Status)
                .HasConversion(converter)
                .HasMaxLength(20)
                .HasDefaultValue(RouteStatus.Active);

            // العلاقة مع Driver
            builder.HasOne(r => r.Driver)
                .WithMany(d => d.Routes)
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // العلاقة مع Subscriptions
            builder.HasMany(r => r.Subscriptions)
                .WithOne(s => s.Route)
                .HasForeignKey(s => s.RouteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
