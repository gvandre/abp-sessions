using System;
using System.Threading.Tasks;
using Inteliventas.Erp.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace Inteliventas.Erp.Web.Pages.Clientes
{
    public class EditModalModel : ErpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateClienteDto Cliente { get; set; }

        private readonly IClienteAppService _clienteAppService;

        public EditModalModel(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public async Task OnGetAsync()
        {
            var clienteDto = await _clienteAppService.GetAsync(Id);
            Cliente = ObjectMapper.Map<ClienteDto, CreateUpdateClienteDto>(clienteDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _clienteAppService.UpdateAsync(Id, Cliente);
            return NoContent();
        }
    }
}
