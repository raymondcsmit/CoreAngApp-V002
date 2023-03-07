using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    public class SubjectTypeMap : IEntityTypeConfiguration<SubjectType>
    {
        public void Configure(EntityTypeBuilder<SubjectType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.ToTable("SubjectType");
        }
    }
}
