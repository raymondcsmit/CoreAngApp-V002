using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DatabaseOptionsFactory
    {
        private readonly IConfiguration _config;

        public DatabaseOptionsFactory(IConfiguration config)
        {
            _config = config;
        }

        public DbContextOptions<TContext> CreateOptions<TContext>() where TContext : DbContext
        {
            var databaseProvider = _config["DatabaseProvider"];
            var connectionString = _config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            switch (databaseProvider)
            {
                case "Sqlite":
                    connectionString = _config.GetConnectionString("SqliteConnection");
                    optionsBuilder.UseSqlite(connectionString);
                    break;
                case "SqlServer":
                    connectionString = _config.GetConnectionString("SqlServerConnection");
                    optionsBuilder.UseSqlServer(connectionString);
                    break;
                default: break;
            }

            return optionsBuilder.Options;
        }
    }
}
