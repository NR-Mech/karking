using Karking.Back.Extensions;

namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleSession
{
    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime EntryAt { get; set; }

    public string PayToken { get; set; }
    public int PaidAmount { get; set; }
    public DateTime? PaidAt { get; set; }

    public DateTime? ExitLimit { get; set; }
    public DateTime? ExitAt { get; set; }

    private VehicleSession() {}

    public VehicleSession(Guid vehicleId)
    {
        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        EntryAt = DateTime.Now;
        PayToken = KarkingExtensions.GetPayToken();
    }
}
