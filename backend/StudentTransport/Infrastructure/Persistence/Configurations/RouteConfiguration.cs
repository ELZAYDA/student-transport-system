using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // Enum Conversion (الأفضل والأبسط)
            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .HasDefaultValue(RouteStatus.Active);

            // Database Constraints (مهم جدًا في Production)
            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Routes_CurrentOccupancy",
                "[CurrentOccupancy] >= 0"));

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Routes_Capacity",
                "[Capacity] > 0"));

            // Indexes لتحسين الأداء
            builder.HasIndex(r => r.DriverId);
            builder.HasIndex(r => r.Status);

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