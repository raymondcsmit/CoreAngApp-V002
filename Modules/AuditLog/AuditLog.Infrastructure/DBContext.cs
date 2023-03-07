using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AuditLog.Infrastructure
{
    public class AuditLogContext : DbContext
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        public AuditLogContext(CoreDbContextOptionsBuilder optB)
       : base(optB.SelectDatabase<AuditLogContext>())
        {
            OptionsBuilder = optB;

            this.GetType().Assembly.GetName();
        }
        public virtual DbSet<AuditEntry> AuditEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (OptionsBuilder.TypeOfDB == "Sqlite")
            {
                builder.Entity<AuditEntry>()
            .HasKey(e => e.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
            }
            else
            {
                builder.Entity<AuditEntry>()
               .Property(e => e.Id)
               .ValueGeneratedOnAdd();
            }
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}