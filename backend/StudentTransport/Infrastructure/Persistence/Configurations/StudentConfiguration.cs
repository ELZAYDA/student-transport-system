// Infrastructure/Persistence/Configurations/StudentConfiguration.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.StudentCode)
            .HasMaxLength(20);

        builder.Property(s => s.ParentName)
            .HasMaxLength(100);

        builder.Property(s => s.ParentPhone)
            .HasMaxLength(20);

        builder.Property(s => s.SchoolName)
            .HasMaxLength(200);

        builder.Property(s => s.Grade)
            .HasMaxLength(50);

        builder.Property(s => s.Address)
            .HasMaxLength(500);

        builder.Property(s => s.MedicalNotes)
            .HasMaxLength(1000);

        // لا يوجد علاقة مباشرة مع ApplicationUser هنا
        // يمكنك فقط حفظ UserId

        // فهرسة
        builder.Property(s => s.StudentCode)
       .IsRequired()
       .HasMaxLength(20);

        builder.Property(s => s.UserId)
       .IsRequired()
       .HasMaxLength(450); // كل user يمكن أن يكون طالب واحد فقط
    }
}