using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class SettingMap : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().HasDefaultValueSql("NEWSEQUENTIALID()");
            builder.Property(o => o.SettingKey).HasMaxLength(100);
            builder.Property(o => o.SettingValue).HasMaxLength(500);
            builder.Property(o => o.SettingGroup).HasMaxLength(100);
            builder.ToTable("Setting");
        }
    }

}
