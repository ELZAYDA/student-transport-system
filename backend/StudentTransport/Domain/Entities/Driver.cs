// Domain/Entities/Driver.cs
using Domain.Common;

namespace Domain.Entities
{
    public class Driver : BaseEntity
    {
        public int UserId { get; private set; }  // أو string إذا كنت تستخدم IdentityUser الافتراضي
        public string LicenseNumber { get; private set; } = null!;
        public DateTime LicenseExpiryDate { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime? HireDate { get; private set; }
        public string? EmergencyContact { get; private set; }
        public string? EmergencyPhone { get; private set; }

        // إزالة هذا السطر: public User User { get; private set; } = null!;
        // بدلاً منه، يمكنك إضافة:
        // public ApplicationUser? ApplicationUser { get; set; } // إذا أردت navigation property

        public Vehicle Vehicle { get; private set; } = null!;
        public ICollection<Route> Routes { get; private set; } = new List<Route>();

        private Driver() { }

        public Driver(int userId, string licenseNumber, DateTime licenseExpiryDate)
        {
            UserId = userId;
            LicenseNumber = licenseNumber;
            LicenseExpiryDate = licenseExpiryDate;
            HireDate = DateTime.UtcNow;
        }

        // إضافة Methods لتحديث البيانات
        public void UpdateDriverInfo(string licenseNumber, DateTime licenseExpiryDate,
                                    string? emergencyContact, string? emergencyPhone)
        {
            LicenseNumber = licenseNumber;
            LicenseExpiryDate = licenseExpiryDate;
            EmergencyContact = emergencyContact;
            EmergencyPhone = emergencyPhone;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}