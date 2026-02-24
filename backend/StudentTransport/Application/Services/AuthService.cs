//// Application/Services/AuthService.cs
//using Application.DTOs.Requests.Auth;
//using Application.DTOs.Responses.Auth;
//using Application.Interfaces.Services;
//using Domain.Entities;
//using System;
//using System.Security.Claims;
//using System.Text;

//namespace Application.Services;

//public class AuthService : IAuthService
//{
//    private readonly UserManager<ApplicationUser> _userManager;
//    private readonly IConfiguration _config;
//    private readonly AppDbContext _db; // لإضافة Student/Driver record

//    public AuthService(
//        UserManager<ApplicationUser> userManager,
//        IConfiguration config,
//        AppDbContext db)
//    {
//        _userManager = userManager;
//        _config = config;
//        _db = db;
//    }

//    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
//    {
//        // 1. Check email not taken
//        var existing = await _userManager.FindByEmailAsync(request.Email);
//        if (existing is not null)
//            throw new InvalidOperationException("Email already registered");

//        // 2. Validate role
//        var allowedRoles = new[] { "Student", "Driver", "Admin" };
//        if (!allowedRoles.Contains(request.Role))
//            throw new ArgumentException("Invalid role");

//        // 3. Create Identity user
//        var user = new ApplicationUser
//        {
//            FirstName = request.FirstName,
//            LastName = request.LastName,
//            Email = request.Email,
//            UserName = request.Email,
//            Role = request.Role
//        };

//        var result = await _userManager.CreateAsync(user, request.Password);
//        if (!result.Succeeded)
//        {
//            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
//            throw new InvalidOperationException($"Registration failed: {errors}");
//        }

//        // 4. Add to role
//        await _userManager.AddToRoleAsync(user, request.Role);

//        // 5. Create domain entity based on role
//        await CreateDomainEntityAsync(user, request);

//        // 6. Generate token
//        return GenerateAuthResponse(user);
//    }

//    public async Task<AuthResponse> LoginAsync(LoginRequest request)
//    {
//        var user = await _userManager.FindByEmailAsync(request.Email)
//            ?? throw new UnauthorizedAccessException("Invalid credentials");

//        var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);
//        if (!validPassword)
//            throw new UnauthorizedAccessException("Invalid credentials");

//        return GenerateAuthResponse(user);
//    }

//    // ─── Private Helpers ────────────────────────────────────────

//    private async Task CreateDomainEntityAsync(ApplicationUser user, RegisterRequest request)
//    {
//        if (request.Role == "Student")
//        {
//            var student = new Student(user.Id, request.StudentCode);
//            _db.Set<Student>().Add(student);
//            await _db.SaveChangesAsync();

//            user.StudentId = student.Id;
//            await _userManager.UpdateAsync(user);
//        }
//        else if (request.Role == "Driver")
//        {
//            if (string.IsNullOrWhiteSpace(request.LicenseNumber) || request.LicenseExpiryDate is null)
//                throw new ArgumentException("Driver must provide license info");

//            var driver = new Driver(user.Id, request.LicenseNumber, request.LicenseExpiryDate.Value);
//            _db.Set<Driver>().Add(driver);
//            await _db.SaveChangesAsync();

//            user.DriverId = driver.Id;
//            await _userManager.UpdateAsync(user);
//        }
//        // Admin → no domain entity needed
//    }

//    private AuthResponse GenerateAuthResponse(ApplicationUser user)
//    {
//        var jwtSettings = _config.GetSection("JwtSettings");
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!));
//        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//        var expiry = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"]!));

//        var claims = new[]
//        {
//            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
//            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
//            new Claim(ClaimTypes.Role, user.Role),
//            new Claim("fullName", $"{user.FirstName} {user.LastName}"),
//            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//        };

//        var token = new JwtSecurityToken(
//            issuer: jwtSettings["Issuer"],
//            audience: jwtSettings["Audience"],
//            claims: claims,
//            expires: expiry,
//            signingCredentials: creds
//        );

//        return new AuthResponse
//        {
//            Token = new JwtSecurityTokenHandler().WriteToken(token),
//            Email = user.Email!,
//            FullName = $"{user.FirstName} {user.LastName}",
//            Role = user.Role,
//            ExpiresAt = expiry
//        };
//    }
//}