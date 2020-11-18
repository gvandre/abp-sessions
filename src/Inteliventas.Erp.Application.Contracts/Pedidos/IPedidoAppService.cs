using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Inteliventas.Erp.Pedidos
{
    public interface IPedidoAppService :
        ICrudAppService< //Defines CRUD methods
            PedidoDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdatePedidoDto> //Used to create/update a book*/
    {
        Task<ListResultDto<PedidoClienteDto>> GetPedidoClienteAsync();
        Task<ListResultDto<PedidoVendedorDto>> GetPedidoVendedorAsync();
    }
}
