using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(o => o.MenuText).HasMaxLength(100);
            builder.Property(o => o.MenuURL).HasMaxLength(400);
            builder.HasOne(o => o.Menu2).WithMany(c => c.Menu_ParentIds).HasForeignKey(o => o.ParentId).OnDelete(DeleteBehavior.SetNull);
            builder.Property(o => o.MenuIcon).HasMaxLength(100);
            builder.ToTable("Menu");
        }
    }
}
