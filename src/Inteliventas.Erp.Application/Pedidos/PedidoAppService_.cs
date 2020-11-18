using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Vendedores;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp.Pedidos
{
    public class PedidoAppService_ :
        CrudAppService<
            Pedido, //The Cliente entity
            PedidoDto, //Used to show books
            Guid, //Primary key of the Cliente entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdatePedidoDto>, //Used to create/update a Cliente
         IPedidoAppService//implement the IBookAppService*/
    {
        private readonly IClienteRepository _clienteRepository;

        private readonly IRepository<Vendedor, Guid> _vendedorRepository;

        public PedidoAppService_(
            IRepository<Pedido, Guid> repository,
            IClienteRepository clienteRepository,
            IRepository<Vendedor, Guid> vendedorRepository)
        : base(repository)
        {
            _clienteRepository = clienteRepository;
            _vendedorRepository = vendedorRepository;
        }

        public override async Task<PedidoDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var query = from pedido in Repository
                        join cliente in _clienteRepository on pedido.ClienteId equals cliente.Id
                        join vendedor in _vendedorRepository on pedido.VendedorId equals vendedor.Id
                        where pedido.Id == id
                        select new { pedido, cliente, vendedor };

            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Pedido), id);
            }

            var pedidoDto = ObjectMapper.Map<Pedido, PedidoDto>(queryResult.pedido);
            pedidoDto.ClienteNombre = queryResult.cliente.Nombre;
            pedidoDto.VendedorNombre = queryResult.vendedor.Nombre;

            return pedidoDto;
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

        public async Task<ListResultDto<PedidoVendedorDto>> GetPedidoVendedorAsync()
        {
            var vendedores = await _vendedorRepository.GetListAsync();

            return new ListResultDto<PedidoVendedorDto>(
                ObjectMapper.Map<List<Vendedor>, List<PedidoVendedorDto>>(vendedores)
            );
        }
    }
}
