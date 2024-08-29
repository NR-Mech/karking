namespace Karking.Back.Features.RegisterVehicleEntry;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<VehicleEntry> Entries { get; set; }

    public Vehicle(string plate)
    {
        Id = Guid.NewGuid();
        Plate = plate.ToUpper();
        CreatedAt = DateTime.Now;
    }
}
