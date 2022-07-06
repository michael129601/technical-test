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
    public class MovimientosController : ControllerGeneric
    {
        MovimientosFacede facade;


        public MovimientosController(ApplicationDBContext prmContext) : base(prmContext)
        {
            facade = new MovimientosFacede(prmContext);
        }


       
        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimientosCreate prmCuentas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = await facade.Create(prmCuentas);

                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (MovimientosException mx)
            {
                return StatusCode(mx.StatusHttpCode, GetMessage(mx.Message));
            };
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await facade.GetAll());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await facade.GetById(id));
            }
            catch (MovimientosException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

        // GET api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status204NoContent,await facade.Delete(id));
            }
            catch (MovimientosException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

        // GET api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovimientosUpdate prmMovimientos )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = await facade.Update(id, prmMovimientos);
                return StatusCode(StatusCodes.Status204NoContent, response);
            }
            catch (MovimientosException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }
    }
}
