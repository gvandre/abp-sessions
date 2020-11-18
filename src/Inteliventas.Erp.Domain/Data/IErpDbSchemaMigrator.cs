using System.Threading.Tasks;

namespace Inteliventas.Erp.Data
{
    public interface IErpDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
