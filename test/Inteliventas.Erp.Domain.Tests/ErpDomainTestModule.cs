using Inteliventas.Erp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Inteliventas.Erp
{
    [DependsOn(
        typeof(ErpEntityFrameworkCoreTestModule)
        )]
    public class ErpDomainTestModule : AbpModule
    {

    }
}