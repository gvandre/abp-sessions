using System;
using Volo.Abp.Application.Dtos;

namespace Inteliventas.Erp.Pedidos
{
    public class CreateUpdatePedidoDto : AuditedEntityDto<Guid>
    {
        public Guid ClienteId { get; set; }
        public Guid VendedorId { get; set; }
        public float Total { get; set; }
        public int TotalProductos { get; set; }
    }
}
