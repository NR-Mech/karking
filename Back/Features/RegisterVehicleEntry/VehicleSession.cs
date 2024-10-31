using Karking.Back.Extensions;

namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleSession
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public DateTime EntryAt { get; set; }

    public string PayToken { get; set; }
    public int PaidAmount { get; set; }
    public DateTime? PaidAt { get; set; }

    public DateTime? ExitLimit { get; set; }
    public DateTime? ExitAt { get; set; }

    private VehicleSession() {}

    public VehicleSession(string plate)
    {
        Id = Guid.NewGuid();
        Plate = plate;
        EntryAt = DateTime.Now;
        PayToken = KarkingExtensions.GetPayToken();
    }

    public VehicleSession GetNewAfterExpiration()
    {
        var session = new VehicleSession()
        {
            Id = Guid.NewGuid(),
            Plate = Plate,
            EntryAt = ExitLimit!.Value,
            PayToken = PayToken,
        };

        return session;
    }
}
