using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Inteliventas.Erp.Pedidos
{
    public class Pedido : FullAuditedAggregateRoot<Guid>
    {
        public Guid ClienteId { get; set; }
        public Guid VendedorId { get; set; }
        public float Total { get; set; }
        public int TotalProductos { get; set; }
    }
}
