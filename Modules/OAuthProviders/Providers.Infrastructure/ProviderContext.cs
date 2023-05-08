using Core;
using Microsoft.EntityFrameworkCore;
using Providers.Domain;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Providers.Infrastructure
{
    public class ProviderContext : DbContext
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        public ProviderContext(CoreDbContextOptionsBuilder optB)
       : base(optB.SelectDatabase<ProviderContext>())
        {
            OptionsBuilder = optB;

            this.GetType().Assembly.GetName();
        }
        public virtual DbSet<OAuth2ProviderSettings> ProviderSettingsEntries { get; set; }
        public virtual DbSet<OAuthToken> OAuthTokenEntries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (OptionsBuilder.TypeOfDB == "Sqlite")
            {
                builder.Entity<OAuth2ProviderSettings>()
            .HasKey(e => e.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
                builder.Entity<OAuthToken>()
            .HasKey(e => e.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
            }
            else
            {
                builder.Entity<OAuth2ProviderSettings>()
               .Property(e => e.Id)
               .ValueGeneratedOnAdd();
                builder.Entity<OAuthToken>()
              .Property(e => e.Id)
              .ValueGeneratedOnAdd();
            }
            builder.Entity<OAuthToken>().HasOne(t => t.ProviderSettings).WithMany().HasForeignKey(t => t.ProviderID);
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}