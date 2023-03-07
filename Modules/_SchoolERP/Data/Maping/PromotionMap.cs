using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    

    public class PromotionMap : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.Student_StudentId)
                .WithMany(o => o.Promotion_StudentIds)
                .HasForeignKey(o => o.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.SessionYear_RunningSessionId)
                .WithMany(o => o.Promotion_RunningSessionIds)
                .HasForeignKey(o => o.RunningSessionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.SessionYear_PromoteToSessionId)
                .WithMany(o => o.Promotion_PromoteToSessionIds)
                .HasForeignKey(o => o.PromoteToSessionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Classes_CurrentClassId)
                .WithMany(o => o.Promotion_CurrentClassIds)
                .HasForeignKey(o => o.CurrentClassId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Classes_PromoteToClassId)
                .WithMany(o => o.Promotion_PromoteToClassIds)
                .HasForeignKey(o => o.PromoteToClassId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Section_PromoteToSectionId)
                .WithMany(o => o.Promotion_PromoteToSectionIds)
                .HasForeignKey(o => o.PromoteToSectionId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.ExamMark_ExamMarkId)
                .WithMany(o => o.Promotion_ExamMarkIds)
                .HasForeignKey(o => o.ExamMarkId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(o => o.NextRollNumber).HasMaxLength(100);
            builder.ToTable("Promotion");
        }
    }

    
}
