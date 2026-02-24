// Application/DTOs/Requests/Auth/LoginRequest.cs
namespace Application.DTOs.Requests.Auth;

public class LoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}