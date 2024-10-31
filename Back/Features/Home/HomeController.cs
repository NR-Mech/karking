namespace Karking.Back.Features.Home;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Consumes("application/json"), Produces("application/json")]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Get() => Redirect("/swagger");
}
