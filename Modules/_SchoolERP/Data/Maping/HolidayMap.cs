using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class HolidayMap : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.Title).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Note).HasMaxLength(100).IsRequired();
            builder.ToTable("Holiday");
        }
    }
}
