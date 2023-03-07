using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    public class ExamAttendanceMap : IEntityTypeConfiguration<ExamAttendance>
    {
        public void Configure(EntityTypeBuilder<ExamAttendance> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.ExamAttendance_StudentIds).HasForeignKey(o => o.StudentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ExamTerm_ExamTermId).WithMany(o => o.ExamAttendance_ExamTermIds).HasForeignKey(o => o.ExamTermId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Subject_SubjectId).WithMany(o => o.ExamAttendance_SubjectIds).HasForeignKey(o => o.SubjectId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("ExamAttendance");
        }
    }
}
