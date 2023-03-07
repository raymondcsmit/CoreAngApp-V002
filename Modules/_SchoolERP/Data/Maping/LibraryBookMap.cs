
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolERP.Data.Models;
namespace SchoolERP.Data.Models.Maping
{
    public class LibraryBookMap : IEntityTypeConfiguration<LibraryBook>
    {
        public void Configure(EntityTypeBuilder<LibraryBook> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.BookTitle).HasMaxLength(100);
            builder.Property(o => o.BookId).HasMaxLength(100);
            builder.Property(o => o.ISBNNo).HasMaxLength(100);
            builder.Property(o => o.Edition).HasMaxLength(100);
            builder.Property(o => o.Author).HasMaxLength(100);
            builder.Property(o => o.Language).HasMaxLength(100);
            builder.Property(o => o.Price).HasMaxLength(50);
            builder.Property(o => o.AlmiraNo).HasMaxLength(100);
            builder.Property(o => o.CoverPicture).HasMaxLength(100);
            builder.ToTable("LibraryBook");
        }
    }
}