using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class RoleUserMap : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasOne(c => c.Role_RoleId).WithMany().HasForeignKey(o => o.RoleId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.User_UserId).WithMany().HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("RoleUser");
        }
    }
}
