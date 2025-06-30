using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qtec.infrastructure.Persistence
{
    public class QtecDbContextFactory : IDesignTimeDbContextFactory<QtecDbContext>
    {
        public QtecDbContext CreateDbContext(string[] args)
        {
            // Manually point to qtec.api folder where appsettings.json exists
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "qtec.api");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<QtecDbContext>();
            var connectionString = configuration.GetConnectionString("DevConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new QtecDbContext(optionsBuilder.Options);
        }
    }
}
