using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaNTTDATA.Core.DTOs
{
    public  class ClientesDTO
    {
        [Required]
        [StringLength(100)]
        public string nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string telefono { get; set; }

        [Required]
        [StringLength(100)]
        public string clave { get; set; }

        [Required]
        public bool estado { get; set; }

        public int? edad { get; set; }

        [MaxLength(1)]
        public string? genero { get; set; }


        [MaxLength(15)]
        public string? identificacion { get; set; }
    }
}
