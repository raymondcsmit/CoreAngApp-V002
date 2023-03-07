using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace SchoolERP.Data.Models.Maping
{
    public class MDayMap : IEntityTypeConfiguration<MDay>
    {
        public void Configure(EntityTypeBuilder<MDay> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(20);
            builder.ToTable("MDay");
        }
    }
}
