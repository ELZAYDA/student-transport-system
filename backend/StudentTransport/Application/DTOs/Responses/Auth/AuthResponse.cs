// Application/DTOs/Responses/Auth/AuthResponse.cs
namespace Application.DTOs.Responses.Auth;

public class AuthResponse
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
}