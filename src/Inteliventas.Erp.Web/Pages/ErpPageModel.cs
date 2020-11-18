using Inteliventas.Erp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Inteliventas.Erp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class ErpPageModel : AbpPageModel
    {
        protected ErpPageModel()
        {
            LocalizationResourceType = typeof(ErpResource);
        }
    }
}