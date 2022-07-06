using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.DTOs
{
    public class ClientesUpdateDTO
    {
        
        [StringLength(100)]
        public string? nombres { get; set; }

    
        [StringLength(100)]
        public string? direccion { get; set; }

     
        [StringLength(10)]
        public string? telefono { get; set; }

      
        [StringLength(100)]
        public string? clave { get; set; }

        [Required]
        public bool? estado { get; set; }
    }
}
