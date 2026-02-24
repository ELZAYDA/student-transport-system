// Application/DTOs/Requests/Auth/RegisterRequest.cs
namespace Application.DTOs.Requests.Auth;

public class RegisterRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!; // "Student" | "Driver" | "Admin"

    // Student-specific (optional)
    public string? StudentCode { get; set; }

    // Driver-specific (optional)
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiryDate { get; set; }
}