using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp.Vendedores
{
    public class VendedorAppService :
        CrudAppService<
            Vendedor, 
            VendedorDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateVendedorDto>,
        IVendedorAppService
    {
        public VendedorAppService(IRepository<Vendedor, Guid> repository) : base(repository)
        {
        }
    }
}
