// Domain/Entities/Student.cs
using Domain.Common;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public int UserId { get; private set; }  // أو string
        public string? StudentCode { get; private set; }
        public string? ParentName { get; private set; }
        public string? ParentPhone { get; private set; }
        public string? SchoolName { get; private set; }
        public string? Grade { get; private set; }
        public string? Address { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public string? MedicalNotes { get; private set; }

        // إزالة هذا السطر: public User User { get; private set; } = null!;
        // بدلاً منه:
        // public ApplicationUser? ApplicationUser { get; set; }

        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        private Student() { }

        public Student(int userId, string? studentCode)
        {
            UserId = userId;
            StudentCode = studentCode;
        }

        // إضافة Methods لتحديث البيانات
        public void UpdateStudentInfo(string? studentCode, string? parentName, string? parentPhone,
                                     string? schoolName, string? grade, DateTime? dateOfBirth,
                                     string? address, string? medicalNotes)
        {
            StudentCode = studentCode;
            ParentName = parentName;
            ParentPhone = parentPhone;
            SchoolName = schoolName;
            Grade = grade;
            DateOfBirth = dateOfBirth;
            Address = address;
            MedicalNotes = medicalNotes;
        }
    }
}
