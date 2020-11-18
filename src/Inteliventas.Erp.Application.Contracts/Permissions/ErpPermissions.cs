namespace Inteliventas.Erp.Permissions
{
    public static class ErpPermissions
    {
        public const string GroupName = "Erp";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static class Clientes
        {
            public const string Default = GroupName + ".Clientes";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}