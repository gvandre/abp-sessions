using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Inteliventas.Erp.Vendedores
{
    public interface IVendedorAppService :
        ICrudAppService<
            VendedorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateVendedorDto>
    {

    }
}
