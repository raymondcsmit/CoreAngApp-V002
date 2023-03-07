using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class SubjectMap : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property(o => o.SubjectName).HasMaxLength(100);
            builder.Property(o => o.SubjectCode).HasMaxLength(50);
            builder.Property(o => o.AuthorName).HasMaxLength(100);
            builder.HasOne(c => c.SubjectType_SubjectTypeId).WithMany(o => o.Subject_SubjectTypeIds).HasForeignKey(o => o.SubjectTypeId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.Subject_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User_TeacherId).WithMany(o => o.Subject_TeacherIds).HasForeignKey(o => o.TeacherId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(o => o.PassMark).HasMaxLength(50);
            builder.Property(o => o.FullMark).HasMaxLength(50);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.ToTable("Subject");
        }
    }

}
