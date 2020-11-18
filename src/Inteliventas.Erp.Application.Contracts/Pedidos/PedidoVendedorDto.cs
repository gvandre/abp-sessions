using System;
using Volo.Abp.Application.Dtos;

namespace Inteliventas.Erp.Pedidos
{
    public class PedidoVendedorDto : EntityDto<Guid>
    {
        public string Nombre { get; set; }
    }
}
