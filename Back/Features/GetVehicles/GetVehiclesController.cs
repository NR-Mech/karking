using Karking.Back.Extensions;

namespace Karking.Back.Features.GetVehicles;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class GetVehiclesController(KarkingDbContext ctx) : ControllerBase
{
    [HttpGet("vehicles"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get()
    {
        var sessions = await ctx.Sessions.OrderByDescending(x => x.EntryAt).ToListAsync();

        return Ok(sessions.ConvertAll(x => new {
            Plate = x.Plate,
            EntryAt = x.EntryAt.ToStr(),
            PayToken = x.PayToken,
            PaidAmount = x.PaidAmount,
            PaidAt = x.PaidAt.ToStr(),
            ExitLimit = x.ExitLimit.ToStr(),
            ExitAt = x.ExitAt.ToStr(),
        }));
    }
}
