using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewsManageModule.Data.EF
{
    public class NMMDbContextFactory : IDesignTimeDbContextFactory<NMMDbContext>
    {
        public NMMDbContext CreateDbContext(string[] args)
        {
            //throw new NotImplementedException();
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("NMMDb");
            var optionsBuilder = new DbContextOptionsBuilder<NMMDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new NMMDbContext(optionsBuilder.Options);
        }
    }
}
