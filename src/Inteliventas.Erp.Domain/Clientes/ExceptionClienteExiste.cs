using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace Inteliventas.Erp.Clientes
{
    public class ExceptionClienteExiste : BusinessException
    {
        public ExceptionClienteExiste(string tipoDoc, string doc)
            : base(ErpDomainErrorCodes.ClienteExiste)
        {
            WithData("typeDoc", tipoDoc);

            WithData("doc", doc);
        }
    }
}
