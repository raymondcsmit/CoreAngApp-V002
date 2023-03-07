using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureApp.Infrastructure
{
    public class ConfigureAppDbContext : DbContext
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        public ConfigureAppDbContext(CoreDbContextOptionsBuilder optB)
       : base(optB.SelectDatabase<ConfigureAppDbContext>())
        {
            OptionsBuilder = optB;
            this.GetType().Assembly.GetName();
        }
        public DbSet<ApplicationModule> Applications { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<DisplayedColumn> DisplayedColumns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationModule>(entity =>
            {
                if (OptionsBuilder.TypeOfDB == "Sqlite")               
                    entity.HasKey(e => e.Id).HasAnnotation("Sqlite:Autoincrement", true);               
                else
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Forms).WithOne(e => e.Application).HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                if (OptionsBuilder.TypeOfDB == "Sqlite")
                    entity.HasKey(e => e.Id).HasAnnotation("Sqlite:Autoincrement", true);
                else
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Fields).WithOne(e => e.Form).HasForeignKey(e => e.Id);
                entity.HasMany(e => e.DisplayedColumns).WithOne(e => e.Form).HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Field>(entity =>
            {
                if (OptionsBuilder.TypeOfDB == "Sqlite")
                    entity.HasKey(e => e.Id).HasAnnotation("Sqlite:Autoincrement", true);
                else
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Options).WithOne(e => e.Field).HasForeignKey(e => e.Id);
            });

            modelBuilder.Entity<Option>(entity =>
            {
                if (OptionsBuilder.TypeOfDB == "Sqlite")
                    entity.HasKey(e => e.Id).HasAnnotation("Sqlite:Autoincrement", true);
                else
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<DisplayedColumn>(entity =>
            {
                if (OptionsBuilder.TypeOfDB == "Sqlite")
                    entity.HasKey(e => e.Id).HasAnnotation("Sqlite:Autoincrement", true);
                else
                    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }

}
