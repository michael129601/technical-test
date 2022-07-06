using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Entity.Models
{
    public class Clientes 
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        [Column("cliente_id")]
        public int Clienteid { get; set; }

        [Column("contrasenia")]
        public string Contrasenia { get; set; }

        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey("Persona")]
        [Column("persona_id")]
        public int PersonaId { get; set; }


        public Persona Persona { get; set; }




    }
}
