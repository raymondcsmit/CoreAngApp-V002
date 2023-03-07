using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class NoticeMap : IEntityTypeConfiguration<Notice>
    {
        public void Configure(EntityTypeBuilder<Notice> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.HasOne(c => c.Role_NoticeForRoleId).WithMany(o => o.Notice_NoticeForRoleIds).HasForeignKey(o => o.NoticeForRoleId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Details).HasMaxLength(1000);
            builder.ToTable("Notice");
        }
    }
}
