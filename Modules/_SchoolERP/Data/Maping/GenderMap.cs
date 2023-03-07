using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasDefaultValueSql("newsequentialid()").ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(50);
            builder.ToTable("Gender");
        }
    }

}
