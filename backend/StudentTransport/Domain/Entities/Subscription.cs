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
        if (studentId <= 0)
            throw new ArgumentException("Invalid student");

        if (routeId <= 0)
            throw new ArgumentException("Invalid route");

        if (startDate == default)
            throw new ArgumentException("Invalid start date");

        StudentId = studentId;
        RouteId = routeId;
        StartDate = startDate;
    }

    public void Cancel()
    {
        if (Status == SubscriptionStatus.Cancelled)
            throw new InvalidOperationException("Subscription already cancelled");

        Status = SubscriptionStatus.Cancelled;
        EndDate = DateTime.UtcNow;
    }

    public void Expire()
    {
        if (Status != SubscriptionStatus.Active)
            throw new InvalidOperationException("Only active subscriptions can expire");

        Status = SubscriptionStatus.Expired;
        EndDate = DateTime.UtcNow;
    }
}