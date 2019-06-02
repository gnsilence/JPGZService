using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace JPGZService.EntityFrameworkCore
{
  public static class JPGZServicePostgreSqlDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JPGZServicePostgreSqlDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JPGZServicePostgreSqlDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
