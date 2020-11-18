using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Inteliventas.Erp.Web
{
    [Dependency(ReplaceServices = true)]
    public class ErpBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Erp";
    }
}
