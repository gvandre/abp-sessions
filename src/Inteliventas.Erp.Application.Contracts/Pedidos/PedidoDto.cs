using System;
using Volo.Abp.Application.Dtos;

namespace Inteliventas.Erp.Pedidos
{
    public class PedidoDto : AuditedEntityDto<Guid>
    {
        public Guid ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public Guid VendedorId { get; set; }
        public string VendedorNombre { get; set; }
        public float Total { get; set; }
        public float TotalProductos { get; set; }
    }
}
