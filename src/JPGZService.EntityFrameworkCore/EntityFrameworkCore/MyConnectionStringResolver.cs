using Abp.Configuration.Startup;
using Abp.Domain.Uow;
using JPGZService.Configuration;
using JPGZService.Web;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.EntityFrameworkCore
{
  public  class MyConnectionStringResolver: DefaultConnectionStringResolver
    {
        public MyConnectionStringResolver(IAbpStartupConfiguration configuration)
            : base(configuration)
        {
        }

        public override string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            // if mysql
            if (args["DbContextConcreteType"] as Type == typeof(JPGZServiceMysqlDbContext))
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(JPGZServiceConsts.MysqlConnectionStringName);
            }
            // if postgresql
            if (args["DbContextConcreteType"] as Type == typeof(JPGZServicePostgreSqlDbContext))
            {
                var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());
                return configuration.GetConnectionString(JPGZServiceConsts.PostgreSqlConnectionStringName);
            }
            return base.GetNameOrConnectionString(args);
        }
    }
}
