using Inteliventas.Erp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Inteliventas.Erp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ErpController : AbpController
    {
        protected ErpController()
        {
            LocalizationResource = typeof(ErpResource);
        }
    }
}