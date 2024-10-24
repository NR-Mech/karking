namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleSessionConfig : IEntityTypeConfiguration<VehicleSession>
{
    public void Configure(EntityTypeBuilder<VehicleSession> vehicleSessions)
    {
        vehicleSessions.ToTable("vehicle_sessions");

        vehicleSessions.HasKey(c => c.Id);
        vehicleSessions.Property(c => c.Id).ValueGeneratedNever();
    }
}
