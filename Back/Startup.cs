namespace Karking.Back;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpConfigs();

        services.AddEfCoreConfigs();

        services.AddCorsConfigs();
    }

    public static void Configure(IApplicationBuilder app, KarkingDbContext ctx)
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        app.UseCors();

        app.UseRouting();

        app.UseControllers();
    }
}
