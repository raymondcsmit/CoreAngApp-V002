using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class SessionYearMap : IEntityTypeConfiguration<SessionYear>
    {
        public void Configure(EntityTypeBuilder<SessionYear> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();// ';//'.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.Name).HasMaxLength(50);
            builder.Property(o => o.Details).HasMaxLength(100);
            builder.ToTable("SessionYear");
        }
    }

}
