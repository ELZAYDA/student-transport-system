using Domain.Common;


namespace Domain.Entities;

public class Student : BaseEntity
{
    public int UserId { get; private set; }
    public string FullName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string? Address { get; private set; }

    public User User { get; private set; } = null!;
    public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

    private Student() { }

    public Student(int userId, string fullName, string phone)
    {
        UserId = userId;
        FullName = fullName;
        Phone = phone;
    }
}
