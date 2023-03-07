using Core;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SecurityApp.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DbSet<ApplicationRolePrivileges> ApplicationRolePrivileges { get; set; }
        public DbSet<Privileges> Privileges { get; set; }
        public ApplicationDbContext(CoreDbContextOptionsBuilder optionsBuilder)
       : base(optionsBuilder.SelectDatabase<ApplicationDbContext>())
        {

            this.GetType().Assembly.GetName();
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationRolePrivileges>()
            .HasKey(x => new { x.RoleId, x.PrivilegeId });
            builder.Entity<ApplicationRolePrivileges>()
                .HasOne(x => x.Role)
                .WithMany(x => x.ApplicationRolePrivileges)
                .HasForeignKey(x => x.RoleId);
            builder.Entity<ApplicationRolePrivileges>()
                .HasOne(x => x.Privilege)
                .WithMany(x => x.ApplicationRolePrivileges)
                .HasForeignKey(x => x.PrivilegeId);
        }
    }
}