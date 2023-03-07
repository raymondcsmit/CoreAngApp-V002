using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class GuardianMap : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.FullName).HasMaxLength(100);
            builder.HasOne(c => c.GuardianRelation_GuardianRelationId).WithMany(o => o.Guardian_GuardianRelationIds).HasForeignKey(o => o.GuardianRelationId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.PhoneNumber).HasMaxLength(15);
            builder.Property(o => o.Profession).HasMaxLength(100);
            builder.Property(o => o.Address1).HasMaxLength(200);
            builder.Property(o => o.Address2).HasMaxLength(200);
            builder.Property(o => o.Religion).HasMaxLength(100);
            builder.HasOne(c => c.Role_RoleId).WithMany(o => o.Guardian_RoleIds).HasForeignKey(o => o.RoleId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(o => o.Email).HasMaxLength(50);
            builder.Property(o => o.Password).HasMaxLength(100);
            builder.Property(o => o.ProfilePicture).HasMaxLength(100);
            builder.Property(o => o.About).HasMaxLength(500);
            builder.ToTable("Guardian");
        }
    }

}
