using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DataSyncApp.Infrastructure
{

    public class DataSyncContext : DbContext
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        public DataSyncContext(CoreDbContextOptionsBuilder optB)
       : base(optB.SelectDatabase<DataSyncContext>())
        {
            OptionsBuilder = optB;

            this.GetType().Assembly.GetName();
        }
        public virtual DbSet<SyncTable> SyncTableEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (OptionsBuilder.TypeOfDB == "Sqlite")
            {
                builder.Entity<SyncTable>()
            .HasKey(e => e.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
            }
            else
            {
                builder.Entity<SyncTable>()
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