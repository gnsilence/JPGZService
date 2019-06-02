using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace JPGZService.EntityFrameworkCore
{
   public static class JPGZServiceMysqlDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JPGZServiceMysqlDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JPGZServiceMysqlDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
