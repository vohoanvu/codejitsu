using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace CodeJitsu.Data;

public class CodeJitsuEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public CodeJitsuEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CodeJitsuDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CodeJitsuDbContext>()
            .Database
            .MigrateAsync();
    }
}
