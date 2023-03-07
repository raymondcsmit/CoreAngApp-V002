
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    public class CertificateTypeMap : IEntityTypeConfiguration<CertificateType>
    {
        public void Configure(EntityTypeBuilder<CertificateType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.CertificateName).HasMaxLength(100);
            builder.Property(o => o.SchoolName).HasMaxLength(100);
            builder.Property(o => o.CertificateText).HasMaxLength(500);
            builder.Property(o => o.FooterLeftText).HasMaxLength(100);
            builder.Property(o => o.FooterMiddleText).HasMaxLength(100);
            builder.Property(o => o.FooterRightText).HasMaxLength(100);
            builder.Property(o => o.Background).HasMaxLength(100);
            builder.ToTable("CertificateType");
        }
    }
}
