using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class MyDocumentMap : IEntityTypeConfiguration<MyDocument>
    {
        public void Configure(EntityTypeBuilder<MyDocument> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.User_UserId).WithMany(o => o.MyDocument_UserIds).HasForeignKey(o => o.UserId);
            builder.HasOne(c => c.Student_StudentId).WithMany(o => o.MyDocument_StudentIds).HasForeignKey(o => o.StudentId);
            builder.Property(o => o.Title).HasMaxLength(100);
            builder.Property(o => o.FileName).HasMaxLength(100);
            builder.Property(o => o.FileExtension).HasMaxLength(10);
            builder.ToTable("MyDocument");
 

        }
    }
}
