using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class TransportVehicleMap : IEntityTypeConfiguration<TransportVehicle>
    {
        public void Configure(EntityTypeBuilder<TransportVehicle> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.VehicleNumber).HasMaxLength(100);
            builder.Property(o => o.VehicleModel).HasMaxLength(100);
            builder.Property(o => o.Driver).HasMaxLength(100);
            builder.Property(o => o.VehicleLicense).HasMaxLength(100);
            builder.Property(o => o.VehicleContact).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.ToTable("TransportVehicle");
        }
    }
}
