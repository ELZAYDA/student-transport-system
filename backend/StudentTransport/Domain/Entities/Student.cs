using Domain.Common;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string UserId { get; private set; } = null!;

        public string? StudentCode { get; private set; }
        public string? ParentName { get; private set; }
        public string? ParentPhone { get; private set; }
        public string? SchoolName { get; private set; }
        public string? Grade { get; private set; }
        public string? Address { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public string? MedicalNotes { get; private set; }

        public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

        private Student() { }

        public Student(string userId, string? studentCode)
        {
            UserId = userId;
            StudentCode = studentCode;
        }

        public void UpdateStudentInfo(
            string? studentCode,
            string? parentName,
            string? parentPhone,
            string? schoolName,
            string? grade,
            DateTime? dateOfBirth,
            string? address,
            string? medicalNotes)
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