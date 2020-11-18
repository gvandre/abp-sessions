using Inteliventas.Erp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Inteliventas.Erp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ErpEntityFrameworkCoreDbMigrationsModule),
        typeof(ErpApplicationContractsModule)
        )]
    public class ErpDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
