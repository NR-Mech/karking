using Karking.Back.Features.RegisterVehicleEntry;

namespace Karking.Back.Database;

public class KarkingDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration.GetSection("DatabaseString").Value);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("karking");

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
