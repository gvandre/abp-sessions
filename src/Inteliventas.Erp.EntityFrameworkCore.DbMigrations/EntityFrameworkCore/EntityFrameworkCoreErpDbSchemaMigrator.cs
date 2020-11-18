using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Inteliventas.Erp.Data;
using Volo.Abp.DependencyInjection;

namespace Inteliventas.Erp.EntityFrameworkCore
{
    public class EntityFrameworkCoreErpDbSchemaMigrator
        : IErpDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreErpDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ErpMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ErpMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}