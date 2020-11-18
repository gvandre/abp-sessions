using System;
using Volo.Abp;

namespace Inteliventas.Erp.Clientes
{
    public class ExceptionClienteNoData : BusinessException
    {
        public ExceptionClienteNoData()
            : base(ErpDomainErrorCodes.ClienteNoData)
        {
        }
    }
}
