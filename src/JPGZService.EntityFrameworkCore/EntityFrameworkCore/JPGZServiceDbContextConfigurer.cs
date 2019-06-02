using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JPGZService.EntityFrameworkCore
{
    public static class JPGZServiceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JPGZServiceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JPGZServiceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
