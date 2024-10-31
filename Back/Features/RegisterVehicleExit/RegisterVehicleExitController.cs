namespace Karking.Back.Features.RegisterVehicleExit;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class RegisterVehicleExitController(KarkingDbContext ctx) : ControllerBase
{
    [HttpPost("vehicles/exit"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Register([FromBody] RegisterVehicleExitIn data)
    {
        var plate = data.Plate.ToUpper();
        var sessions = await ctx.Sessions.Where(x => x.Plate == plate).ToListAsync();

        if (sessions.Count == 0) return BadRequest("Veículo não encontrado");

        var session = sessions.OrderByDescending(x => x.EntryAt).First();
        if (session.PaidAt == null)
        {
            var result = new
            {
                Status = "Pagamento Pendente",
                AmountToPay = Convert.ToInt32(Math.Ceiling((DateTime.Now - session.EntryAt).TotalSeconds/60.0)),
            };
            return BadRequest(result);
        }

        if (session.ExitLimit < DateTime.Now)
        {
            var result = new
            {
                Status = "Período de carência finalizado",
                Now = DateTime.Now,
                session.ExitLimit,
            };
            return BadRequest(result);
        }

        session.ExitAt = DateTime.Now;
        await ctx.SaveChangesAsync();

        return Ok("Obrigado!");
    }
}
