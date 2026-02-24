using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable("Subscriptions");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.StartDate)
                   .IsRequired();

            builder.Property(s => s.EndDate)
                   .IsRequired(false);

            // Enum Conversion (الأبسط والأكثر استقرارًا)
            builder.Property(s => s.Status)
                   .IsRequired()
                   .HasConversion<string>()
                   .HasMaxLength(20)
                   .HasDefaultValue(SubscriptionStatus.Active);

            // العلاقة مع Student
            builder.HasOne(s => s.Student)
                   .WithMany(st => st.Subscriptions)
                   .HasForeignKey(s => s.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // العلاقة مع Route
            builder.HasOne(s => s.Route)
                   .WithMany(r => r.Subscriptions)
                   .HasForeignKey(s => s.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Unique Composite Index (مهم جدًا لمنع التكرار)
            builder.HasIndex(s => new { s.StudentId, s.RouteId })
                   .IsUnique();
        }
    }
}