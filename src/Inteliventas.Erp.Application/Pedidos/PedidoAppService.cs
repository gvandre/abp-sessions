using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Vendedores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp.Pedidos
{
    public class PedidoAppService : CrudAppService<
            Pedido, //The Cliente entity
            PedidoDto, //Used to show books
            Guid, //Primary key of the Cliente entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdatePedidoDto
        >, IPedidoAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IRepository<Vendedor, Guid> _vendedorRepository;
        public PedidoAppService(IRepository<Pedido, Guid> repository,
            IClienteRepository clienteRepository,
            IRepository<Vendedor, Guid> vendedorRepository
        ) : base(repository)
        {
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
        }

        public override async Task<PagedResultDto<PedidoDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = from pedido in Repository
                        join cliente in _clienteRepository on pedido.ClienteId equals cliente.Id
                        join vendedor in _vendedorRepository on pedido.VendedorId equals vendedor.Id
                        orderby input.Sorting
                        select new { pedido, cliente, vendedor };

            query = query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var pedidoDtos = queryResult.Select(x =>
            {
                var pedidoDto = ObjectMapper.Map<Pedido, PedidoDto>(x.pedido);

                pedidoDto.ClienteNombre = x.cliente.nombre;
                pedidoDto.VendedorNombre = x.vendedor.nombre;

                return pedidoDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<PedidoDto>(
                totalCount,
                pedidoDtos
            );
        }
        public async Task<ListResultDto<PedidoClienteDto>> GetPedidoClienteAsync()
        {
            var clientes = await _clienteRepository.GetListAsync();

            return new ListResultDto<PedidoClienteDto>(
                ObjectMapper.Map<List<Cliente>, List<PedidoClienteDto>>(clientes)
            );
        }

        public Task<ListResultDto<PedidoVendedorDto>> GetPedidoVendedorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
