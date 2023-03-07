using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolERP.Data.Models.Maping
{
    public class SalaryGradeMap : IEntityTypeConfiguration<SalaryGrade>
    {
        public void Configure(EntityTypeBuilder<SalaryGrade> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Name).HasMaxLength(100);
            builder.Property(o => o.ShortNote).HasMaxLength(100);
            builder.ToTable("SalaryGrade");
        }
    }
}
