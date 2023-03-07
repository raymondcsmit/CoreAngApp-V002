using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace SchoolERP.Data.Models.Maping
{
    public class ClassRoutineMap : IEntityTypeConfiguration<ClassRoutine>
    {
        public void Configure(EntityTypeBuilder<ClassRoutine> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Classes_ClassId)
                .WithMany(o => o.ClassRoutine_ClassIds)
                .HasForeignKey(o => o.ClassId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Section_SectionId)
                .WithMany(o => o.ClassRoutine_SectionIds)
                .HasForeignKey(o => o.SectionId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Subject_SubjectId)
                .WithMany(o => o.ClassRoutine_SubjectIds)
                .HasForeignKey(o => o.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.User_TeacherId)
                .WithMany(o => o.ClassRoutine_TeacherIds)
                .HasForeignKey(o => o.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.MDay_DayId)
                .WithMany(o => o.ClassRoutine_DayIds)
                .HasForeignKey(o => o.DayId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.RoomNumber).HasMaxLength(50);
            builder.ToTable("ClassRoutine");
        }
    }
}
