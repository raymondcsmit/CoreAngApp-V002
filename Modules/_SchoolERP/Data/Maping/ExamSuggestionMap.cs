using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ExamSuggestionMap : IEntityTypeConfiguration<ExamSuggestion>
    {
        public void Configure(EntityTypeBuilder<ExamSuggestion> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.SuggestionTitle).HasMaxLength(100);
            builder.HasOne(c => c.ExamTerm_ExamTermId)
                .WithMany(o => o.ExamSuggestion_ExamTermIds)
                .HasForeignKey(o => o.ExamTermId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Classes_ClassId)
                .WithMany(o => o.ExamSuggestion_ClassIds)
                .HasForeignKey(o => o.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Subject_SubjectId)
                .WithMany(o => o.ExamSuggestion_SubjectIds)
                .HasForeignKey(o => o.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Suggestion).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(500);
            builder.ToTable("ExamSuggestion");
        }
    }
}
