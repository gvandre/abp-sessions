using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Inteliventas.Erp.Localization;
using Inteliventas.Erp.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Inteliventas.Erp.Web.Menus
{
    public class ErpMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<ErpResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(ErpMenus.Home, l["Menu:Home"], "~/"));

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "Erp",
                    l["Menu:Erp"],
                    icon: "fa fa-book"
                ).AddItem(
                    new ApplicationMenuItem(
                        "Erp.Clientes",
                        l["Menu:Clients"],
                        url: "/Clientes"
                    )
                ).AddItem(
                    new ApplicationMenuItem(
                        "Erp.Vendedores",
                        l["Menu:Vendors"],
                        url: "/Vendedores"
                    )
                )
            );
        }
    }
}
