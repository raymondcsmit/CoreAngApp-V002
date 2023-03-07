using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ExamScheduleMap : IEntityTypeConfiguration<ExamSchedule>
    {
        public void Configure(EntityTypeBuilder<ExamSchedule> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.ExamTerm_ExamTermId).WithMany(o => o.ExamSchedule_ExamTermIds).HasForeignKey(o => o.ExamTermId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.ExamSchedule_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Subject_SubjectId).WithMany(o => o.ExamSchedule_SubjectIds).HasForeignKey(o => o.SubjectId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.RoomNumber).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.ToTable("ExamSchedule");
        }
    }
}
