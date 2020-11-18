using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Pedidos;
using Inteliventas.Erp.Vendedores;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp
{
    public class ErpDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Cliente, Guid> _clienteRepository;
        private readonly IRepository<Vendedor, Guid> _vendedorRepository;
        private readonly IRepository<Pedido, Guid> _pedidoRepository;

        public ErpDataSeederContributor(
            IRepository<Cliente, Guid> clienteRepository,
            IRepository<Vendedor, Guid> vendedorRepository,
            IRepository<Pedido, Guid> pedidoRepository
        )
        {
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _clienteRepository.GetCountAsync() <= 0)
            {
                await _clienteRepository.InsertAsync(
                    new Cliente
                    {
                        Nombre = "Cliente 1",
                        Ruc = "1234568901",
                        Dni = "1234678",
                        Ce = "12346789020"
                    },
                    autoSave: true
                ); ;

                await _clienteRepository.InsertAsync(
                    new Cliente
                    {
                        Nombre = "Cliente 2",
                        Ruc = "1245678902",
                        Dni = "1234569",
                        Ce = "12345678021"
                    },
                    autoSave: true
                );
            }

            if (await _vendedorRepository.GetCountAsync() <= 0)
            {
                await _vendedorRepository.InsertAsync(
                    new Vendedor
                    {
                        Nombre = "Vendedor 1",
                        Ruc = "1234568901",
                        Dni = "1234678",
                        Ce = "12346789020"
                    },
                    autoSave: true
                ); ;

                await _vendedorRepository.InsertAsync(
                    new Vendedor
                    {
                        Nombre = "Vendedor 2",
                        Ruc = "1245678902",
                        Dni = "1234569",
                        Ce = "12345678021"
                    },
                    autoSave: true
                );
            }

            if (await _pedidoRepository.GetCountAsync() <= 0)
            {
                var vendedorTest = await _vendedorRepository.InsertAsync(
                    new Vendedor
                    {
                        Nombre = "Vendedor Test",
                        Ruc = "1234",
                        Dni = "1234",
                        Ce = "1234"
                    },
                    autoSave: true
                );

                var clienteTest = await _clienteRepository.InsertAsync(
                    new Cliente
                    {
                        Nombre = "Cliente Test",
                        Ruc = "1234",
                        Dni = "1234",
                        Ce = "1234"
                    },
                    autoSave: true
                );


                await _pedidoRepository.InsertAsync(
                    new Pedido
                    {
                        ClienteId = clienteTest.Id,
                        VendedorId = vendedorTest.Id,
                        Total = 15,
                        TotalProductos = 1
                    },
                    autoSave: true
                );

            }

            /*if (await _pedidoRepository.GetCountAsync() > 0)
            {
                return;
            }

            Cliente clienteTest = await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Nombre = "Cliente Test",
                    Ruc = "1245678902",
                    Dni = "1234569",
                    Ce = "12345678021"
                }
            );

            Vendedor vendedorTest = await _vendedorRepository.InsertAsync(
                new Vendedor
                {
                    Nombre = "Vendedor Test",
                    Ruc = "1245678902",
                    Dni = "1234569",
                    Ce = "12345678021"
                }
            );

            await _pedidoRepository.InsertAsync(
                new Pedido
                {
                    ClienteId = clienteTest.Id,
                    VendedorId = vendedorTest.Id,
                    Total = 32,
                    TotalProductos = 2
                },
                autoSave: true
            );

            await _pedidoRepository.InsertAsync(
                new Pedido
                {
                    ClienteId = clienteTest.Id,
                    VendedorId = vendedorTest.Id,
                    Total = 15,
                    TotalProductos = 1
                },
                autoSave: true
            );*/
        }
    }
}
