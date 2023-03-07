using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class HostelTypeMap : IEntityTypeConfiguration<HostelType>
    {
        public void Configure(EntityTypeBuilder<HostelType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.ToTable("HostelType");
        }
    }
}
