namespace Karking.Back;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpConfigs();

        services.AddEfCoreConfigs();

        services.AddCorsConfigs();

        services.AddDocsConfigs();
    }

    public static void Configure(IApplicationBuilder app, KarkingDbContext ctx)
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();

        app.UseCors();

        app.UseDocs();

        app.UseRouting();

        app.UseControllers();
    }
}
