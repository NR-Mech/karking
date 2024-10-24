namespace Karking.Back.Features.RegisterVehicleEntry;

public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> vehicle)
    {
        vehicle.ToTable("vehicles");

        vehicle.HasKey(c => c.Id);
        vehicle.Property(c => c.Id).ValueGeneratedNever();

        vehicle.Property(c => c.Plate);

        vehicle.HasMany(x => x.Sessions)
            .WithOne()
            .HasForeignKey(x => x.VehicleId);
    }
}
