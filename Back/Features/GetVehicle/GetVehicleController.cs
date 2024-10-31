namespace Karking.Back.Features.GetVehicle;

[ApiController]
[Consumes("application/json"), Produces("application/json")]
public class GetVehicleController(KarkingDbContext ctx) : ControllerBase
{
    [HttpGet("vehicles/{plate}"), ApiKey]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Get([FromRoute] string plate)
    {
        plate = plate.ToUpper();
        var sessions = await ctx.Sessions.Where(x => x.Plate == plate).ToListAsync();

        if (sessions.Count == 0) return BadRequest("Veículo não encontrado");

        var session = sessions.OrderByDescending(x => x.EntryAt).First();

        if (session.PaidAt == null)
        {
            var result = new
            {
                session.EntryAt,
                Status = "Pagamento Pendente",
                Now = DateTime.Now,
                AmountToPay = Convert.ToInt32(Math.Ceiling((DateTime.Now - session.EntryAt).TotalSeconds/60.0)),
            };
            return Ok(result);
        }

        var result2 = new
        {
            session.EntryAt,
            Status = "Pagamento Realizado",
            session.PaidAt,
            Now = DateTime.Now,
            session.ExitLimit,
        };
        return Ok(result2);
    }
}
