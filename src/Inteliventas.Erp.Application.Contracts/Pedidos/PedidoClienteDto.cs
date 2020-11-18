using System;
using Volo.Abp.Application.Dtos;

namespace Inteliventas.Erp.Pedidos
{
    public class PedidoClienteDto : EntityDto<Guid>
    {
        public string Nombre { get; set; }
    }
}
