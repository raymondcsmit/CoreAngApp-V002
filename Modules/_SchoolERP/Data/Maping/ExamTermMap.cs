using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ExamTermMap : IEntityTypeConfiguration<ExamTerm>
    {
        public void Configure(EntityTypeBuilder<ExamTerm> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.ExamTitle).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.HasOne(c => c.SessionYear_RunningYearId).WithMany(o => o.ExamTerm_RunningYearIds).HasForeignKey(o => o.RunningYearId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("ExamTerm");
        }
    }
}
