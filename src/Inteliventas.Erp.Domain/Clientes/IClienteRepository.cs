using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp.Clientes
{
    public interface IClienteRepository : IRepository<Cliente, Guid>
    {
        Task<Cliente> FindByDniAsync(string dni);
        Task<Cliente> FindByRucAsync(string ruc);
        Task<Cliente> FindByCeAsync(string ce);
    }
}
