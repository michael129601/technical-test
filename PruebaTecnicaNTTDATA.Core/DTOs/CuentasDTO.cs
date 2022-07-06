using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.DTOs
{
    public class CuentasDTO
    {
        [Required]
        public int numero_cuenta { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo { get; set; }

        [Required]
        public double saldo_inicial { get; set; }

        [Required]
        public bool estado { get; set; }

        [Required]
        public int clienteId { get; set; }
    }
}
