using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JPGZService.Configuration;
using JPGZService.Web;

namespace JPGZService.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JPGZServiceDbContextFactory : IDesignTimeDbContextFactory<JPGZServiceDbContext>
    {
        public JPGZServiceDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JPGZServiceDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JPGZServiceDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JPGZServiceConsts.ConnectionStringName));

            return new JPGZServiceDbContext(builder.Options);
        }
    }
}
