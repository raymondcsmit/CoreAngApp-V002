using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class SectionMap : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.Section_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(o => o.SectionName).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.User_TeacherId).WithMany(o => o.Section_TeacherIds).HasForeignKey(o => o.TeacherId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Note).HasMaxLength(500).IsRequired();
            builder.ToTable("Section");
        }
    }
}
