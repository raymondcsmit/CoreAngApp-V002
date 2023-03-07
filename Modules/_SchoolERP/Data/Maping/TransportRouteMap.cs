using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class TransportRouteMap : IEntityTypeConfiguration<TransportRoute>
    {
        public void Configure(EntityTypeBuilder<TransportRoute> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.TransportRouteTitle).HasMaxLength(100);
            builder.Property(o => o.RouteStart).HasMaxLength(150);
            builder.Property(o => o.RouteEnd).HasMaxLength(150);
            builder.Property(o => o.AssignVehicle).HasMaxLength(500);
            builder.ToTable("TransportRoute");
        }
    }
}
