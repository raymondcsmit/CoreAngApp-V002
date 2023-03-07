using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class EmailAttachmentMap : IEntityTypeConfiguration<EmailAttachment>
    {
        public void Configure(EntityTypeBuilder<EmailAttachment> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.EmailMessage_EmailMessageId).WithMany(o => o.EmailAttachment_EmailMessageIds).HasForeignKey(o => o.EmailMessageId).OnDelete(DeleteBehavior.Cascade);//.WillCascadeOnDelete(true);
            builder.Property(o => o.FileUrl).HasMaxLength(300);
            builder.ToTable("EmailAttachment");
 

        }
    }
}
