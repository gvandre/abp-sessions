using System;
using System.Threading.Tasks;
using Inteliventas.Erp.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Inteliventas.Erp.Clientes
{
    public class PedidoAppService :
        CrudAppService<
            Cliente, //The Cliente entity
            ClienteDto, //Used to show books
            Guid, //Primary key of the Cliente entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateClienteDto>, //Used to create/update a Cliente
         IClienteAppService//implement the IBookAppService*/
    {
        private readonly ClienteControl _clienteControl;

        private readonly IRepository<Cliente, Guid> _clienteRepository;
        public PedidoAppService(IRepository<Cliente, Guid> repository, ClienteControl clienteControl)
        : base(repository)
        {
            _clienteControl = clienteControl;
            _clienteRepository = repository;

            // Permission
            GetPolicyName = ErpPermissions.Clientes.Default;
            GetListPolicyName = ErpPermissions.Clientes.Default;
            CreatePolicyName = ErpPermissions.Clientes.Create;
            UpdatePolicyName = ErpPermissions.Clientes.Edit;
            DeletePolicyName = ErpPermissions.Clientes.Delete;
        }

        override
        public async Task<ClienteDto> CreateAsync(CreateUpdateClienteDto input)
        {
            var cliente = await _clienteControl.CreateAsync(
                input.Nombre,
                input.Dni,
                input.Ruc,
                input.Ce
            );

            await _clienteRepository.InsertAsync(cliente);

            return ObjectMapper.Map<Cliente, ClienteDto>(cliente);
        }

        override
        public async Task<ClienteDto> UpdateAsync(Guid Id, CreateUpdateClienteDto input)
        {
            var cliente = await _clienteRepository.GetAsync(Id);

            if (input.Dni != cliente.Dni)
            {
                await _clienteControl.ChangeDniAsync(cliente, input.Dni);
            }

            if (input.Ruc != cliente.Ruc)
            {
                await _clienteControl.ChangeRucAsync(cliente, input.Ruc);
            }

            if (input.Ce != cliente.Ce)
            {
                await _clienteControl.ChangeCeAsync(cliente, input.Ce);
            }

            return ObjectMapper.Map<Cliente, ClienteDto>(cliente);
        }
    }
}
