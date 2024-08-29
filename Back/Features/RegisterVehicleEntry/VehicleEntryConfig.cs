namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleEntryConfig : IEntityTypeConfiguration<VehicleEntry>
{
    public void Configure(EntityTypeBuilder<VehicleEntry> vehicleEntries)
    {
        vehicleEntries.ToTable("vehicle_entries");

        vehicleEntries.HasKey(c => c.Id);
        vehicleEntries.Property(c => c.Id).ValueGeneratedNever();
    }
}
