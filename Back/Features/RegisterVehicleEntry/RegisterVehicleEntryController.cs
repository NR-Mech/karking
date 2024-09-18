namespace Karking.Back.Features.RegisterVehicleEntry;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class RegisterVehicleEntryController(KarkingDbContext ctx) : ControllerBase
{
    [HttpPost("vehicles"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Register([FromBody] RegisterVehicleEntryIn data)
    {
        var plate = data.Plate.ToUpper();
        var vehicle = await ctx.Vehicles.FirstOrDefaultAsync(x => x.Plate == plate);

        if (vehicle == null)
        {
            vehicle = new Vehicle(plate);
            ctx.Add(vehicle);
        }
        
        var vehicleEntry = new VehicleEntry(vehicle.Id);
        ctx.Add(vehicleEntry);

        await ctx.SaveChangesAsync();

        return Ok(vehicle);
    }
}
