using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNTTDATA.ApiContracts
{
    public class ReportesQueryParamcs
    {
        [Required]
        public DateTime? FechaInicio { get; set; }
        [Required]
        public DateTime? FechaFin { get; set; }
        [Required]
        public int? ClienteId { get; set; }
    }
}
