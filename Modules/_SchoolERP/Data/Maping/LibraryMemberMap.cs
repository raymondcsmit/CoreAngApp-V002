using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class LibraryMemberMap : IEntityTypeConfiguration<LibraryMember>
    {
        public void Configure(EntityTypeBuilder<LibraryMember> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.LibraryId).HasMaxLength(100);
            builder.HasOne(o => o.User_UserId).WithMany(c => c.LibraryMember_UserIds).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(o => o.Student_StudentId).WithMany(c => c.LibraryMember_StudentIds).HasForeignKey(o => o.StudentId).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable("LibraryMember");
        }
    }
}
