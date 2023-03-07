using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// This class can be used to dynamically configure the database context options based on the configuration, allowing the application to switch between different database providers without having to change the code.
    /// </summary>
    public class CoreDbContextOptionsBuilder : DbContextOptionsBuilder<DbContext>
    {
        private readonly IConfigurationRoot config;
        private string typeOfDb;
        public string TypeOfDB { get { return typeOfDb; } }
        public CoreDbContextOptionsBuilder(IConfigurationRoot _config)
        {
            config = _config;
        }
        /// <summary>
        /// The SelectDatabase method uses the databaseProvider value from the configuration to determine which database provider to use and retrieves the corresponding connection string. Based on the databaseProvider value, the method sets the options for either a SQLite or a SQL Server database using the UseSqlite or UseSqlServer method of the DbContextOptionsBuilder<TContext> class, respectively. The resulting options are then returned as an instance of DbContextOptions<TContext>.
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public DbContextOptions<TContext> SelectDatabase<TContext>() where TContext : DbContext
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            var databaseProvider = config["DatabaseProvider"];
            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            switch (databaseProvider)
            {
                case "Sqlite":
                    connectionString = config.GetConnectionString("SqliteConnection");
                    optionsBuilder.UseSqlite(connectionString, b => b.MigrationsAssembly("CoreAngApp"));// x => x.MigrationsAssembly(typeof(TContext).Assembly.FullName));
                    typeOfDb = "Sqlite";
                    break;
                case "SqlServer":
                    connectionString = config.GetConnectionString("SqlServerConnection");
                    optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("CoreAngApp"));//x => x.MigrationsAssembly(typeof(TContext).Assembly.FullName));
                    typeOfDb = "SqlServer";
                    break;
                default: break;
            }

            return optionsBuilder.Options;
        }
    }

}
