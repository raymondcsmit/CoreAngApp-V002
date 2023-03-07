using Microsoft.EntityFrameworkCore;
namespace SchoolERP.Data.Models.Maping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.ValueGeneratedOnAdd();//.HasDatabaseGeneratedOption(Microsoft.EntityFrameworkCore.Metadata.SqlServerValueGenerationStrategy.IdentityColumn);
            builder.Property(o => o.UserName).HasMaxLength(100);
            builder.Property(o => o.Password).HasMaxLength(100);
            builder.Property(o => o.FullName).HasMaxLength(100);
            builder.HasOne(c => c.Designation_DesignationId).WithMany(o => o.User_DesignationIds).HasForeignKey(o => o.DesignationId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(o => o.Phone).HasMaxLength(15);
            builder.Property(o => o.Address1).HasMaxLength(500);
            builder.Property(o => o.Address2).HasMaxLength(500);
            builder.HasOne(c => c.Gender_GenderId).WithMany(o => o.User_GenderIds).HasForeignKey(o => o.GenderId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(o => o.BloodGroup).HasMaxLength(10);
            builder.Property(o => o.Religion).HasMaxLength(100);
            builder.HasOne(c => c.Role_RoleId).WithMany(o => o.User_RoleIds).HasForeignKey(o => o.RoleId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(o => o.Email).HasMaxLength(50);
            builder.Property(o => o.ProfilePicture).HasMaxLength(100);
            builder.Property(o => o.Resume).HasMaxLength(100);
            builder.HasOne(c => c.SalaryGrade_SalaryGradeId).WithMany(o => o.User_SalaryGradeIds).HasForeignKey(o => o.SalaryGradeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(c => c.SalaryType_SalaryTypeId).WithMany(o => o.User_SalaryTypeIds).HasForeignKey(o => o.SalaryTypeId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(o => o.Facebook).HasMaxLength(100);
            builder.Property(o => o.Linkedin).HasMaxLength(100);
            builder.Property(o => o.Twitter).HasMaxLength(100);
            builder.Property(o => o.Pinterest).HasMaxLength(100);
            builder.Property(o => o.Youtube).HasMaxLength(100);
            builder.Property(o => o.Instagram).HasMaxLength(100);
            builder.Property(o => o.GooglePlus).HasMaxLength(100);            
            builder.Property(o => o.AboutUs).HasMaxLength(500);
            builder.ToTable("User");
 

        }
    }
}
