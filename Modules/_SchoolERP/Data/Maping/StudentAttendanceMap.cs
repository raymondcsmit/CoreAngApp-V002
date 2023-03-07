using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class StudentAttendanceMap : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.StudentAttendance_StudentIds).HasForeignKey(o => o.StudentId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("StudentAttendance");
        }
    }
}
