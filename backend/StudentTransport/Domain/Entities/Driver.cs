using Domain.Common;

namespace Domain.Entities;

public class Driver : BaseEntity
{
    public int UserId { get; private set; }
    public string FullName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string LicenseNumber { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    public User User { get; private set; } = null!;
    public Vehicle Vehicle { get; private set; } = null!;
    public ICollection<Route> Routes { get; private set; } = new List<Route>();

    private Driver() { }

    public Driver(int userId, string fullName, string phone, string licenseNumber)
    {
        UserId = userId;
        FullName = fullName;
        Phone = phone;
        LicenseNumber = licenseNumber;
    }
}
