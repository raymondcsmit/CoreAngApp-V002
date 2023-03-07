using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class HostelRoomMap : IEntityTypeConfiguration<HostelRoom>
    {
        public void Configure(EntityTypeBuilder<HostelRoom> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.Hostel_HostalId).WithMany(o => o.HostelRoom_HostalIds).HasForeignKey(o => o.HostalId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.RoomNo).HasMaxLength(100);
            builder.ToTable("HostelRoom");
        }
    }

}
