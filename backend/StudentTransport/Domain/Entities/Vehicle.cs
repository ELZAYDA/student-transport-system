using Domain.Common;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public int DriverId { get; private set; }
    public string PlateNumber { get; private set; } = null!;
    public int Capacity { get; private set; }
    public string Type { get; private set; } = null!;
    public bool IsActive { get; private set; } = true;

    public Driver Driver { get; private set; } = null!;

    private Vehicle() { }

    public Vehicle(int driverId, string plateNumber, int capacity, string type)
    {
        DriverId = driverId;
        PlateNumber = plateNumber;
        Capacity = capacity;
        Type = type;
    }
}
