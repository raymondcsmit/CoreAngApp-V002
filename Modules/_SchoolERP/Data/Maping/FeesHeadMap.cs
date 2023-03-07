using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class FeesHeadMap : IEntityTypeConfiguration<FeesHead>
    {
        public void Configure(EntityTypeBuilder<FeesHead> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.Property(o => o.Note).HasMaxLength(100);
            builder.ToTable("FeesHead");
 

        }
    }
}
