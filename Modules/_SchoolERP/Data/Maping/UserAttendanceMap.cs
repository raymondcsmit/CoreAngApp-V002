using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class UserAttendanceMap : IEntityTypeConfiguration<UserAttendance>
    {
        public void Configure(EntityTypeBuilder<UserAttendance> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.User_UserId).WithMany(o => o.UserAttendance_UserIds).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("UserAttendance");
        }
    }
}
