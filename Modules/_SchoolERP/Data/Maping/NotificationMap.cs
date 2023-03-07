using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.TableName).HasMaxLength(100);
            builder.Property(o => o.Details).HasMaxLength(200);
            builder.Property(o => o.ProcessToUrl).HasMaxLength(200);
            builder.ToTable("Notification");
 

        }
    }
}
