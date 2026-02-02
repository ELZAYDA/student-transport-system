// Infrastructure/Persistence/Configurations/DriverConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("Drivers");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.LicenseNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.LicenseExpiryDate)
            .IsRequired();

        builder.Property(d => d.EmergencyContact)
            .HasMaxLength(100);

        builder.Property(d => d.EmergencyPhone)
            .HasMaxLength(20);

        builder.Property(d => d.IsActive)
            .HasDefaultValue(true);

        builder.Property(d => d.HireDate)
            .HasDefaultValueSql("GETDATE()");

        // لا يوجد علاقة مباشرة مع ApplicationUser هنا
        // يمكنك فقط حفظ UserId

        builder.HasOne(d => d.Vehicle)
            .WithOne(v => v.Driver)
            .HasForeignKey<Vehicle>(v => v.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Routes)
            .WithOne(r => r.Driver)
            .HasForeignKey(r => r.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}