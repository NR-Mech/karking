namespace Karking.Back.Features.Reset;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class ResetController(KarkingDbContext ctx) : ControllerBase
{
    [HttpPost("reset"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Reset()
    {
        await ctx.Database.EnsureDeletedAsync();
        await ctx.Database.EnsureCreatedAsync();

        return Ok();
    }
}
