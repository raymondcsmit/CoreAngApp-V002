using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class HostelMap : IEntityTypeConfiguration<Hostel>
    {
        public void Configure(EntityTypeBuilder<Hostel> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property(o => o.HostelName).HasMaxLength(100);
            builder.HasOne(c => c.HostelType_HostelTypeId).WithMany(o => o.Hostel_HostelTypeIds).HasForeignKey(o => o.HostelTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Address).HasMaxLength(200);
            builder.Property(o => o.ContactNumber).HasMaxLength(15);
            builder.Property(o => o.Note).HasMaxLength(200);
            builder.ToTable("Hostel");
        }
    }
}
