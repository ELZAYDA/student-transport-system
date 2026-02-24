using Domain.Common;

namespace Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string UserId { get; private set; } = null!;

        public string LicenseNumber { get; private set; } = null!;
        public DateTime LicenseExpiryDate { get; private set; }

        public bool IsActive { get; private set; } = true;
        public DateTime? HireDate { get; private set; }

        public string? EmergencyContact { get; private set; }
        public string? EmergencyPhone { get; private set; }

        public Vehicle? Vehicle { get; private set; }
        public ICollection<Route> Routes { get; private set; } = new List<Route>();

        private Driver() { }

        public Driver(string userId, string licenseNumber, DateTime licenseExpiryDate)
        {
            UserId = userId;
            LicenseNumber = licenseNumber;
            LicenseExpiryDate = licenseExpiryDate;
            HireDate = DateTime.UtcNow;
        }

        public void UpdateDriverInfo(
            string licenseNumber,
            DateTime licenseExpiryDate,
            string? emergencyContact,
            string? emergencyPhone)
        {
            LicenseNumber = licenseNumber;
            LicenseExpiryDate = licenseExpiryDate;
            EmergencyContact = emergencyContact;
            EmergencyPhone = emergencyPhone;
        }

        public void AssignVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;
    }
}