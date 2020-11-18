using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Inteliventas.Erp.Vendedores
{
    public class Vendedor : AuditedAggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string Dni { get; set; }
        public string Ce { get; set; }
    }
}
