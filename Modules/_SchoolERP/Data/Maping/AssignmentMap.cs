using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class AssignmentMap : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();//.UseIdentityColumn();
            builder.Property(o => o.AssignmentTitle).HasMaxLength(100);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.Assignment_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Subject_SubjectId).WithMany(o => o.Assignment_SubjectIds).HasForeignKey(o => o.SubjectId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.AssignmentFile).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(500);
            builder.HasOne(c => c.SessionYear_RunningYearId).WithMany(o => o.Assignment_RunningYearIds).HasForeignKey(o => o.RunningYearId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("Assignment");
        }
    }
}
