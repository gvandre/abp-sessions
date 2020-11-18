using AutoMapper;
using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Pedidos;
using Inteliventas.Erp.Vendedores;

namespace Inteliventas.Erp
{
    public class ErpApplicationAutoMapperProfile : Profile
    {
        public ErpApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Cliente, ClienteDto>();

            CreateMap<CreateUpdateClienteDto, Cliente>();

            CreateMap<Vendedor, VendedorDto>();

            CreateMap<CreateUpdateVendedorDto, Vendedor>();


            CreateMap<Pedido, PedidoDto>();
            CreateMap<Cliente, PedidoClienteDto>();
            CreateMap<Vendedor, PedidoVendedorDto>();
        }
    }
}
