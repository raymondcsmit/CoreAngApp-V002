using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class LedgerHeadMap : IEntityTypeConfiguration<LedgerHead>
    {
        public void Configure(EntityTypeBuilder<LedgerHead> builder)
        {
             builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.Head).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.HasOne(c => c.LedgerHead2).WithMany(o => o.LedgerHead_ParentIds).HasForeignKey(o => o.ParentId);
            builder.ToTable("LedgerHead");
 

        }
    }
}
