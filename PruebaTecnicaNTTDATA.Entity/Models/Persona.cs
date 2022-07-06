using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Models
{
    public class Persona : IdentityModel
    {
        [Column("nombre")]
        [Display(Name = "LastName")]
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [Column("edad")]
        public int? Edad { get; set; }

        [MaxLength(1)]
        [Column("genero")]
        public string? Genero { get; set; }


        [MaxLength(15)]
        [Column("identificacion")]
        public string? Identificacion { get; set; }

        [Column("direccion")]
        [MaxLength(100)]
        public string? Direccion { get; set; }

        [Column("telefono")]
        [MaxLength(15)]
        public string? Telefono { get; set; }


       



    }
}
