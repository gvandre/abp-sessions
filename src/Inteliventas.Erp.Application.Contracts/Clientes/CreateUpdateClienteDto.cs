using System;
using System.ComponentModel.DataAnnotations;

namespace Inteliventas.Erp.Clientes
{
    public class CreateUpdateClienteDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [StringLength(11)]
        public string Ruc { get; set; }
        [StringLength(8)]
        public string Dni { get; set; }
        [StringLength(12)]
        public string Ce { get; set; }
    }
}
