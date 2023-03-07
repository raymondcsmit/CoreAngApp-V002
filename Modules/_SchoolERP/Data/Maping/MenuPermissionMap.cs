using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class MenuPermissionMap : IEntityTypeConfiguration<MenuPermission>
    {
        public void Configure(EntityTypeBuilder<MenuPermission> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(c => c.Menu_MenuId).WithMany(o => o.MenuPermission_MenuIds).HasForeignKey(o => o.MenuId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Role_RoleId).WithMany(o => o.MenuPermission_RoleIds).HasForeignKey(o => o.RoleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User_UserId).WithMany(o => o.MenuPermission_UserIds).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.ToTable("MenuPermission");
        }
    }

}
