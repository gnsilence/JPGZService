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
   public class JPGZServiceMysqlDbContextFactory: IDesignTimeDbContextFactory<JPGZServiceMysqlDbContext>
    {
        public JPGZServiceMysqlDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JPGZServiceMysqlDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JPGZServiceMysqlDbContextConfigurer.Configure(
                builder,
                configuration.GetConnectionString(JPGZServiceConsts.MysqlConnectionStringName)
            );

            return new JPGZServiceMysqlDbContext(builder.Options);
        }
    }
}
