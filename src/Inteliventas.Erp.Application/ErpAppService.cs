using System;
using System.Collections.Generic;
using System.Text;
using Inteliventas.Erp.Localization;
using Volo.Abp.Application.Services;

namespace Inteliventas.Erp
{
    /* Inherit your application services from this class.
     */
    public abstract class ErpAppService : ApplicationService
    {
        protected ErpAppService()
        {
            LocalizationResource = typeof(ErpResource);
        }
    }
}
