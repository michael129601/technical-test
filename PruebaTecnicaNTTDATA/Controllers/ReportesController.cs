using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNTTDATA.ApiContracts;
using PruebaTecnicaNTTDATA.Core.ExceptionHandle;
using PruebaTecnicaNTTDATA.Core.Facades;
using PruebaTecnicaNTTDATA.Entity.Connector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaNTTDATA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerGeneric
    {
        ReporteFacade facade;


        public ReportesController(ApplicationDBContext prmContext) : base(prmContext)
        {
            facade = new ReporteFacade(prmContext);
        }


       
        // POST api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ReportesQueryParamcs reporte)
        {
            try
            {
                if (reporte.FechaInicio.Value.Date > reporte.FechaFin.Value.Date)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, GetMessage("Fecha Inicio no Puede ser mayor a fecha Fin"));
                }
                var response = await facade.generatedReport(reporte.FechaInicio, reporte.FechaFin, reporte.ClienteId);

                return Ok(response);
            }
            catch (MovimientosException mx)
            {
                return StatusCode(mx.StatusHttpCode, GetMessage(mx.Message));
            };
        }

       
    }
}
