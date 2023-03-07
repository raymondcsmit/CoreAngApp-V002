using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class EventMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.EventTitle).HasMaxLength(100);
            builder.HasOne(c => c.Role_EventForRoleId)
                    .WithMany(o => o.Event_EventForRoleIds)
                    .HasForeignKey(o => o.EventForRoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.EventPlace).HasMaxLength(100);
            builder.Property(o => o.EventImage).HasMaxLength(100);
            builder.Property(o => o.Details).HasMaxLength(1000);
            builder.ToTable("Event");
        }
    }
}
