using AutoMapper;
using Inteliventas.Erp.Clientes;
using Inteliventas.Erp.Vendedores;

namespace Inteliventas.Erp.Web
{
    public class ErpWebAutoMapperProfile : Profile
    {
        public ErpWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<ClienteDto, CreateUpdateClienteDto>();

            CreateMap<VendedorDto, CreateUpdateVendedorDto>();
        }
    }
}
