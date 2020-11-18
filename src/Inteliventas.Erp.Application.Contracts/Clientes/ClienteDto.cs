using System;
using Volo.Abp.Application.Dtos;

namespace Inteliventas.Erp.Clientes
{
    public class ClienteDto : AuditedEntityDto<Guid>
    {
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Dni { get; set; }
        public string Ce { get; set; }
    }
}
