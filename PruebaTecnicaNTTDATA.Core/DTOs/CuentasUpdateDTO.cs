using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.DTOs
{
    public class CuentasUpdateDTO
    {

        [Required]
        public string? tipo { get; set; }

        [Required]
        public double saldo_inicial { get; set; }

        public bool? estado { get; set; }

    }
}
