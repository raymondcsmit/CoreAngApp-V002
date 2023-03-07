using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace SchoolERP.Data.Models.Maping
{
    public class NewsMap : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.Property(o => o.NewsImage).HasMaxLength(100);
            builder.Property(o => o.NewsText).HasMaxLength(2000);
            builder.ToTable("News");
        }
    }
}
