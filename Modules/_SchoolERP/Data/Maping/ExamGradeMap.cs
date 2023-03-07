using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SchoolERP.Data.Models.Maping
{
    public class ExamGradeMap : IEntityTypeConfiguration<ExamGrade>
    {
        public void Configure(EntityTypeBuilder<ExamGrade> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.GradeName).HasMaxLength(20).IsRequired();
            builder.Property(o => o.Note).HasMaxLength(200).IsRequired();
            builder.ToTable("ExamGrade");
        }
    }
}
