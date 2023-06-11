using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeJitsu.Data;

public class CodeJitsuDbContextFactory : IDesignTimeDbContextFactory<CodeJitsuDbContext>
{
    public CodeJitsuDbContext CreateDbContext(string[] args)
    {

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CodeJitsuDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new CodeJitsuDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
