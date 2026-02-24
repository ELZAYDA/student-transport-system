// Application/Interfaces/Services/IAuthService.cs
using Application.DTOs.Requests.Auth;
using Application.DTOs.Responses.Auth;

namespace Application.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);
    Task<AuthResponse> LoginAsync(LoginRequest request);
}