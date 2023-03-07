using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ClassesMap : IEntityTypeConfiguration<Classes>
    {
        public void Configure(EntityTypeBuilder<Classes> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasAnnotation("DatabaseGeneratedOption", DatabaseGeneratedOption.Identity);
            builder.Property(o => o.ClassName).HasMaxLength(100);
            builder.Property(o => o.AliasName).HasMaxLength(100);
            builder.HasOne(c => c.User_TeacherId).WithMany(o => o.Classes_TeacherIds).HasForeignKey(o => o.TeacherId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Note).HasMaxLength(500);
            builder.ToTable("Classes");
        }
    }

}
