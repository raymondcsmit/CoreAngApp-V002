using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class LibraryIssueAndReturnMap : IEntityTypeConfiguration<LibraryIssueAndReturn>
    {
        public void Configure(EntityTypeBuilder<LibraryIssueAndReturn> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(o => o.LibraryBook_LibraryBookId).WithMany(c => c.LibraryIssueAndReturn_LibraryBookIds).HasForeignKey(o => o.LibraryBookId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(o => o.LibraryMember_LibraryMemberId).WithMany(c => c.LibraryIssueAndReturn_LibraryMemberIds).HasForeignKey(o => o.LibraryMemberId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("LibraryIssueAndReturn");
        }
    }
}
