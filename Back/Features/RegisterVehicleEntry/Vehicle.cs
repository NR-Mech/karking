namespace Karking.Back.Features.RegisterVehicleEntry;

public class Vehicle
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<VehicleSession> Sessions { get; set; }

    private Vehicle() {}

    public Vehicle(string plate)
    {
        Id = Guid.NewGuid();
        Plate = plate.ToUpper();
        CreatedAt = DateTime.Now;
        Sessions = [new VehicleSession(Id)];
    }

    public void NewSession()
    {
        Sessions.Add(new VehicleSession(Id));
    }
}
