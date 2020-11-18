using System;
using System.Threading.Tasks;
using Inteliventas.Erp.Clientes;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Inteliventas.Erp.EntityFrameworkCore.Clientes
{
    public class EfCoreClienteRepository : EfCoreRepository<ErpDbContext, Cliente, Guid>,
            IClienteRepository
    {
        public EfCoreClienteRepository(IDbContextProvider<ErpDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
        public async Task<Cliente> FindByCeAsync(string ce)
        {
            return await DbSet.FirstOrDefaultAsync(cliente => cliente.Ce == ce);
        }

        public async Task<Cliente> FindByDniAsync(string dni)
        {
            return await DbSet.FirstOrDefaultAsync(cliente => cliente.Dni == dni);
        }

        public async Task<Cliente> FindByRucAsync(string ruc)
        {
            return await DbSet.FirstOrDefaultAsync(cliente => cliente.Ruc == ruc);
        }
    }
}
