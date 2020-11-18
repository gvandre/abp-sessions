using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Inteliventas.Erp.Data
{
    /* This is used if database provider does't define
     * IErpDbSchemaMigrator implementation.
     */
    public class NullErpDbSchemaMigrator : IErpDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}