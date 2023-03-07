

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{

    public class AppSettingMap : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.SchoolName).HasMaxLength(100);
            builder.Property(o => o.Address).HasMaxLength(200);
            builder.Property(o => o.Phone).HasMaxLength(15);
            builder.Property(o => o.Fax).HasMaxLength(20);
            builder.Property(o => o.Email).HasMaxLength(50);
            builder.Property(o => o.Currency).HasMaxLength(50);
            builder.Property(o => o.CurrencySymbol).HasMaxLength(10);
            builder.HasOne(c => c.Language_LanguageId).WithMany(o => o.AppSetting_LanguageIds).HasForeignKey(o => o.LanguageId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Logo).HasMaxLength(100);
            builder.HasOne(c => c.SessionYear_RunningYearId).WithMany(o => o.AppSetting_RunningYearIds).HasForeignKey(o => o.RunningYearId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Location).HasMaxLength(50);
            builder.Property(o => o.Facebook).HasMaxLength(100);
            builder.Property(o => o.Twitter).HasMaxLength(100);
            builder.Property(o => o.Linkedin).HasMaxLength(100);
            builder.Property(o => o.GooglePlus).HasMaxLength(100);
            builder.Property(o => o.Youtube).HasMaxLength(100);
            builder.Property(o => o.Instagram).HasMaxLength(100);
            builder.Property(o => o.Pinterest).HasMaxLength(100);
            builder.Property(o => o.Footer).HasMaxLength(500);
            builder.ToTable("AppSetting");
        }
    }

}
