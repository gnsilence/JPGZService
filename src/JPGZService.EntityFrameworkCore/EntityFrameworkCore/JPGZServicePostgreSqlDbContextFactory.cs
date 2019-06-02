using JPGZService.Configuration;
using JPGZService.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.EntityFrameworkCore
{
    public class JPGZServicePostgreSqlDbContextFactory : IDesignTimeDbContextFactory<JPGZServicePostgreSqlDbContext>
    {
        public JPGZServicePostgreSqlDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JPGZServicePostgreSqlDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JPGZServicePostgreSqlDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JPGZServiceConsts.PostgreSqlConnectionStringName));

            return new JPGZServicePostgreSqlDbContext(builder.Options);
        }
    }
}
