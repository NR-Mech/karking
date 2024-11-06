using Karking.Back.Extensions;

namespace Karking.Back.Features.GetVehicle;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class PayVehicleController(KarkingDbContext ctx) : ControllerBase
{
    [HttpPost("vehicles/{plate}/pay"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get([FromRoute] string plate, [FromBody] PayVehicleIn data)
    {
        plate = plate.ToUpper();
        var sessions = await ctx.Sessions.Where(x => x.Plate == plate).ToListAsync();

        if (sessions.Count == 0) return BadRequest("Veículo não encontrado");

        var session = sessions.OrderByDescending(x => x.EntryAt).First();

        if (session.PayToken != data.Token.ToString()) return BadRequest("Token inválido");

        if (session.PaidAt == null)
        {
            session.PaidAt = DateTime.Now;
            session.PaidAmount = Convert.ToInt32(Math.Ceiling((DateTime.Now - session.EntryAt).TotalSeconds/60.0));
            session.ExitLimit = DateTime.Now.AddMinutes(1);
            await ctx.SaveChangesAsync();

            var result = new
            {
                EntryAt = session.EntryAt.ToStr(),
                Status = "Pagamento Realizado",
                Now = DateTime.Now.ToStr(),
                ExitLimit = session.ExitLimit.ToStr(),
            };

            return Ok(result);
        }

        return Ok();
    }
}
