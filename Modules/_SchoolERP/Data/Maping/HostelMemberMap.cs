using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    public class HostelMemberMap : IEntityTypeConfiguration<HostelMember>
    {
        public void Configure(EntityTypeBuilder<HostelMember> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.HostelRoom_HostelRoomId).WithMany(o => o.HostelMember_HostelRoomIds).HasForeignKey(o => o.HostelRoomId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User_UserId).WithMany(o => o.HostelMember_UserIds).HasForeignKey(o => o.UserId);
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.HostelMember_StudentIds).HasForeignKey(o => o.StudentId);
            builder.ToTable("HostelMember");
        }
    }
}
