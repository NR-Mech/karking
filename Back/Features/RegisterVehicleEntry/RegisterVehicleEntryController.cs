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
        var sessions = await ctx.Sessions.Where(x => x.Plate == plate).ToListAsync();

        if (sessions.Count == 0)
        {
            ctx.Add(new VehicleSession(plate));
            await ctx.SaveChangesAsync();
            return Ok();
        }

        if (sessions.Any(x => x.PaidAt == null))
        {
            return BadRequest("Saiu sem pagar");
        }

        ctx.Add(new VehicleSession(plate));
        await ctx.SaveChangesAsync();
        return Ok();
    }
}
