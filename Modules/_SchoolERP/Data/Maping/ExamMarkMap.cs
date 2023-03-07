using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ExamMarkMap : IEntityTypeConfiguration<ExamMark>
    {
        public void Configure(EntityTypeBuilder<ExamMark> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.ExamMark_StudentIds).HasForeignKey(o => o.StudentId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ExamTerm_ExamTermId).WithMany(o => o.ExamMark_ExamTermIds).HasForeignKey(o => o.ExamTermId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.ExamMark_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Subject_SubjectId).WithMany(o => o.ExamMark_SubjectIds).HasForeignKey(o => o.SubjectId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Section_SectionId).WithMany(o => o.ExamMark_SectionIds).HasForeignKey(o => o.SectionId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.ExamGrade_ExamGradeId).WithMany(o => o.ExamMark_ExamGradeIds).HasForeignKey(o => o.ExamGradeId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Remark).HasMaxLength(100);
            builder.ToTable("ExamMark");
        }
    }

}
