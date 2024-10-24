namespace Karking.Back.Features.RegisterVehicleEntry;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class RegisterVehicleEntryController(KarkingDbContext ctx) : ControllerBase
{
    [HttpPost("vehicles/entry"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Register([FromBody] RegisterVehicleEntryIn data)
    {
        var plate = data.Plate.ToUpper();
        var vehicle = await ctx.Vehicles.Include(x => x.Sessions).FirstOrDefaultAsync(x => x.Plate == plate);

        if (vehicle == null)
        {
            vehicle = new Vehicle(plate);
            ctx.Add(vehicle);
            await ctx.SaveChangesAsync();
            return Ok();
        }

        if (vehicle.Sessions.Any(x => x.PaidAt == null))
        {
            return BadRequest("Saiu sem pagar");
        }

        vehicle.NewSession();
        await ctx.SaveChangesAsync();

        return Ok();
    }
}
