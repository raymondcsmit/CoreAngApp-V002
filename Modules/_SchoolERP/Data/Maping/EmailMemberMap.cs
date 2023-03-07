using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class EmailMemberMap : IEntityTypeConfiguration<EmailMember>
    {
        public void Configure(EntityTypeBuilder<EmailMember> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.EmailMessage_EmailMessageId).WithMany(o => o.EmailMember_EmailMessageIds).HasForeignKey(o => o.EmailMessageId).OnDelete(DeleteBehavior.NoAction); //.WillCascadeOnDelete(false);
            builder.ToTable("EmailMember");
 

        }
    }
}
