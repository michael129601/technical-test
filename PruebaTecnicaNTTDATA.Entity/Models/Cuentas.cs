using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Models
{
    public class Cuentas : IdentityModel
    {
        [Column("numero_cuenta")]
        public int? NumeroCuenta { get; set; }

        [MaxLength(1)]
        [Column("tipo_cuenta")]
        public string? TipoCuenta { get; set; }

        [Column("saldo_inicial")]
        public double? SaldoInicial { get; set; }

        [Column("estado")]
        public bool? Estado { get; set; }

        [ForeignKey("Clientes")]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        public Clientes Clientes { get; set; }



    }
}
