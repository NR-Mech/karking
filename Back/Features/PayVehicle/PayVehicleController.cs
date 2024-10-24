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
        var vehicle = await ctx.Vehicles
            .Include(x => x.Sessions)
            .FirstOrDefaultAsync(x => x.Plate == plate);

        if (vehicle == null) return BadRequest("Veículo não encontrado");

        var session = vehicle.Sessions.OrderByDescending(x => x.EntryAt).First();

        if (session.PayToken != data.Token.ToString()) return BadRequest("Token inválido");

        if (session.PaidAt == null)
        {
            session.PaidAt = DateTime.Now;
            session.PaidAmount = Convert.ToInt32(Math.Round((DateTime.Now - session.EntryAt).TotalMinutes)) + 1;
            session.ExitLimit = DateTime.Now.AddMinutes(1);
            await ctx.SaveChangesAsync();

            var result = new
            {
                session.EntryAt,
                Status = "Pagamento Realizado",
                Now = DateTime.Now,
                session.ExitLimit,
            };

            return Ok(result);
        }

        return Ok();
    }
}
