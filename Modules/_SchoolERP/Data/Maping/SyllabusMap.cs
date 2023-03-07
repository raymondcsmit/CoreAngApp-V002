using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class SyllabusMap : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.Syllabus_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Subject_SubjectId).WithMany(o => o.Syllabus_SubjectIds).HasForeignKey(o => o.SubjectId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.SyllabusFile).HasMaxLength(100);
            builder.Property(o => o.ExtraNote).HasMaxLength(500);
            builder.HasOne(c => c.SessionYear_RunningYearId).WithMany(o => o.Syllabus_RunningYearIds).HasForeignKey(o => o.RunningYearId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Syllabus");
        }
    }

}
