using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class VisitorMap : IEntityTypeConfiguration<Visitor>
    {
        public void Configure(EntityTypeBuilder<Visitor> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.Property(o => o.Phone).HasMaxLength(15);
            builder.Property(o => o.ComingFrom).HasMaxLength(150);
            builder.Property(o => o.MeetTo).HasMaxLength(100);
            builder.Property(o => o.ReasonToMeet).HasMaxLength(200);
            builder.Property(o => o.Remarks).HasMaxLength(200);
            builder.ToTable("Visitor");
        }
    }
}
