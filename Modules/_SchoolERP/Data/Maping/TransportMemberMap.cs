using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class TransportMemberMap : IEntityTypeConfiguration<TransportMember>
    {
        public void Configure(EntityTypeBuilder<TransportMember> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.TransportRoute_TransportRouteId).WithMany(o => o.TransportMember_TransportRouteIds).HasForeignKey(o => o.TransportRouteId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User_UserId).WithMany(o => o.TransportMember_UserIds).HasForeignKey(o => o.UserId).IsRequired(false);
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.TransportMember_StudentIds).HasForeignKey(o => o.StudentId).IsRequired(false);
            builder.ToTable("TransportMember");
        }
    }
}
