using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Subscription : BaseEntity
{
    public int StudentId { get; private set; }
    public int RouteId { get; private set; }
    public SubscriptionStatus Status { get; private set; } = SubscriptionStatus.Active;
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }

    public Student Student { get; private set; } = null!;
    public Route Route { get; private set; } = null!;

    private Subscription() { }

    public Subscription(int studentId, int routeId, DateTime startDate)
    {
        StudentId = studentId;
        RouteId = routeId;
        StartDate = startDate;
    }

    public void Cancel()
    {
        Status = SubscriptionStatus.Cancelled;
        EndDate = DateTime.UtcNow;
    }
}
