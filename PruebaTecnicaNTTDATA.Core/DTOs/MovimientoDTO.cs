using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.DTOs
{
    public  class MovimientoDTO
    {

        [Required]
        [StringLength(1)]
        public string tipo_movimiento { get; set; }

        [Required]
        public double valor { get; set; }

        [Required]
        public int numero_cuenta { get; set; }

    }
}
