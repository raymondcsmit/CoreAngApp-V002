using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class SalaryTypeMap : IEntityTypeConfiguration<SalaryType>
    {
        public void Configure(EntityTypeBuilder<SalaryType> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasDefaultValueSql("NEWID()").ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.ToTable("SalaryType");
        }
    }



}
