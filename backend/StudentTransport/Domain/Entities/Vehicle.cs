using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Vehicle : BaseEntity
{
    public int DriverId { get; private set; }
    public string PlateNumber { get; private set; } = null!;
    public int Capacity { get; private set; }

    public VehicleType Type { get; private set; }
    public bool IsActive { get; private set; } = true;

    public Driver Driver { get; private set; } = null!;

    private Vehicle() { }

    public Vehicle(int driverId, string plateNumber, int capacity, VehicleType type)
    {
        if (string.IsNullOrWhiteSpace(plateNumber))
            throw new ArgumentException("Plate number is required");

        if (capacity <= 0)
            throw new ArgumentException("Invalid vehicle capacity");

        DriverId = driverId;
        PlateNumber = plateNumber;
        Capacity = capacity;
        Type = type;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}