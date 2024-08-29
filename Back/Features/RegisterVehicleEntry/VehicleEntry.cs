namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleEntry
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime CreatedAt { get; set; }

    public VehicleEntry(Guid vehicleId)
    {
        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        CreatedAt = DateTime.Now;
    }
}
