using System.Threading.Tasks;
using Inteliventas.Erp.Vendedores;
using Microsoft.AspNetCore.Mvc;

namespace Inteliventas.Erp.Web.Pages.Vendedores
{
    public class CreateModalModel : ErpPageModel
    {
        [BindProperty]
        public CreateUpdateVendedorDto Vendedor { get; set; }

        private readonly IVendedorAppService _vendedorAppService;

        public CreateModalModel(IVendedorAppService vendedorAppService)
        {
            _vendedorAppService = vendedorAppService;
        }

        public void OnGet()
        {
            Vendedor = new CreateUpdateVendedorDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _vendedorAppService.CreateAsync(Vendedor);

            return NoContent();
        }
    }
}
