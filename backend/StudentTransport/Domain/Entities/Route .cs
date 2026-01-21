using Domain.Common;
using Domain.Enums;


namespace Domain.Entities;

public class Route : BaseEntity
{
    public int DriverId { get; private set; }
    public string Name { get; private set; } = null!;
    public string StartPoint { get; private set; } = null!;
    public string EndPoint { get; private set; } = null!;
    public TimeSpan DepartureTime { get; private set; }
    public int Capacity { get; private set; }
    public int CurrentOccupancy { get; private set; }
    public RouteStatus Status { get; private set; } = RouteStatus.Active;

    public Driver Driver { get; private set; } = null!;
    public ICollection<Subscription> Subscriptions { get; private set; } = new List<Subscription>();

    private Route() { }

    public Route(int driverId, string name, string start, string end, TimeSpan time, int capacity)
    {
        DriverId = driverId;
        Name = name;
        StartPoint = start;
        EndPoint = end;
        DepartureTime = time;
        Capacity = capacity;
    }
}
