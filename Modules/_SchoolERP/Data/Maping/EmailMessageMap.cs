using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class EmailMessageMap : IEntityTypeConfiguration<EmailMessage>
    {
        public void Configure(EntityTypeBuilder<EmailMessage> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.Subject).HasMaxLength(200);
            builder.Property(o => o.MailText);
            builder.ToTable("EmailMessage");
 

        }
    }
}
