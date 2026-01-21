using Domain.Common;
using Domain.Enums;


namespace Domain.Entities;

public class User : BaseEntity
{
    public string Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }

    public Student? Student { get; private set; }
    public Driver? Driver { get; private set; }

    private User() { }

    public User(string email, string passwordHash, UserRole role)
    {
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }
}
