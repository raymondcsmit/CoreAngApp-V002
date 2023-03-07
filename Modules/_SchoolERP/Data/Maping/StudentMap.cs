using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasAnnotation("DatabaseGeneratedOption", Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property(o => o.FullName).HasMaxLength(100);
            builder.HasOne(c => c.Guardian_GuardianId).WithMany(o => o.Student_GuardianIds).HasForeignKey(o => o.GuardianId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.PhoneNumber).HasMaxLength(15);
            builder.Property(o => o.Address1).HasMaxLength(200);
            builder.Property(o => o.Address2).HasMaxLength(200);
            builder.Property(o => o.Religion).HasMaxLength(100);
            builder.HasOne(c => c.Role_RoleId).WithMany(o => o.Student_RoleIds).HasForeignKey(o => o.RoleId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Email).HasMaxLength(50);
            builder.Property(o => o.Password).HasMaxLength(100);
            builder.Property(o => o.ProfilePicture).HasMaxLength(100);
            builder.HasOne(c => c.Gender_GenderId).WithMany(o => o.Student_GenderIds).HasForeignKey(o => o.GenderId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.BloodGroup).HasMaxLength(20);
            builder.HasOne(c => c.Classes_ClassId).WithMany(o => o.Student_ClassIds).HasForeignKey(o => o.ClassId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Section_SectionId).WithMany(o => o.Student_SectionIds).HasForeignKey(o => o.SectionId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.RollNumber).HasMaxLength(100);
            builder.Property(o => o.RegistrationNo).HasMaxLength(100);
            builder.Property(o => o.About).HasMaxLength(500);
            builder.ToTable("Student");
        }
    }
}
