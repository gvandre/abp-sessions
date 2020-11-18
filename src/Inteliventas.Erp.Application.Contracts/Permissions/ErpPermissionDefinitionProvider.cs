using Inteliventas.Erp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Inteliventas.Erp.Permissions
{
    public class ErpPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var erpGroup = context.AddGroup(ErpPermissions.GroupName, L("Permission:Erp"));

            //Define your own permissions here. Example:
            //myGroup.AddPermission(ErpPermissions.MyPermission1, L("Permission:MyPermission1"));

            var clientsPermission = erpGroup.AddPermission(ErpPermissions.Clientes.Default, L("Permission:Clients"));
            clientsPermission.AddChild(ErpPermissions.Clientes.Create, L("Permission:Clients.Create"));
            clientsPermission.AddChild(ErpPermissions.Clientes.Edit, L("Permission:Clients.Edit"));
            clientsPermission.AddChild(ErpPermissions.Clientes.Delete, L("Permission:Clients.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ErpResource>(name);
        }
    }
}
