using CodeJitsu.Entities.Fighter;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace CodeJitsu.Data;

public class CodeJitsuDbContext : AbpDbContext<CodeJitsuDbContext>
{
    public CodeJitsuDbContext(DbContextOptions<CodeJitsuDbContext> options)
        : base(options)
    {
    }

    public DbSet<Fighter> Fighters { get; set; }
    public DbSet<BeltRank> BeltRanks { get; set; }
    public DbSet<Technique> Techniques { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own entities here */
        builder.Entity<AppUser>(b =>
        {
            b.HasOne(x => x.Fighter).WithOne().HasForeignKey<AppUser>(x => x.FighterId);
        });
    }
}
