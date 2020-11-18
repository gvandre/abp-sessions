using Volo.Abp.Modularity;

namespace Inteliventas.Erp
{
    [DependsOn(
        typeof(ErpApplicationModule),
        typeof(ErpDomainTestModule)
        )]
    public class ErpApplicationTestModule : AbpModule
    {

    }
}