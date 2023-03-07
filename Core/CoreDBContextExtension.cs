using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    
    public static class CoreDBContextExtension
    {
        public static DbContextOptionsBuilder<TContext> UseDatabase<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder, IConfiguration config) where TContext : DbContext
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            var databaseProvider = config["DatabaseProvider"];

            switch (databaseProvider)
            {
                case "Sqlite":
                    connectionString = config.GetConnectionString("SqliteConnection");
                    optionsBuilder.UseSqlite(connectionString, x => x.MigrationsAssembly(typeof(TContext).Assembly.FullName));
                    break;
                case "SqlServer":
                    connectionString = config.GetConnectionString("SqlServerConnection");
                    optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(TContext).Assembly.FullName));
                    break;
                default: break;
            }

            return optionsBuilder;
        }
    }

}
