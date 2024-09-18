namespace Karking.Back.Features.GetVehicles;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class GetVehiclesController(KarkingDbContext ctx) : ControllerBase
{
    [HttpGet("vehicles"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get()
    {
        var vehicles = await ctx.Vehicles
            .Include(x => x.Entries)
            .OrderByDescending(x => x.CreatedAt).ToListAsync();

        foreach (var vehicle in vehicles)
        {
            vehicle.Entries = vehicle.Entries.OrderByDescending(x => x.CreatedAt).ToList();
        }

        return Ok(vehicles);
    }
}
