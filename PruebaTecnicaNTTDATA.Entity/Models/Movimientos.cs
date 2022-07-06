using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaNTTDATA.Entity.Models
{
    public  class Movimientos : IdentityModel
    {
        [Column("fecha")]
        public DateTime? Fecha { get; set; }

        [MaxLength(1)]
        [Column("tipo_movimiento")]
        public string TipoMovimiento { get; set; }

        [Column("valor")]
        public double? Valor { get; set; }

        [Column("saldo")]
        public double? Saldo { get; set; }

        [ForeignKey("Cuentas")]
        [Column("cuentas_id")]
        public int CuentasId { get; set; }


        public Cuentas Cuentas { get; set; }



    }
}
