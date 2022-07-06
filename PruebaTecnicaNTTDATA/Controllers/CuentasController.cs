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
    public class CuentasController : ControllerGeneric
    {
        CuentasFacade cuentasFacade;

        public CuentasController(ApplicationDBContext prmContext) : base(prmContext)
        {
            cuentasFacade = new CuentasFacade(prmContext);
        }


        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await cuentasFacade.GetAll());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
               return Ok(await cuentasFacade.GetById(id));
            }
            catch(CuentasException cex)
            {
               return  StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CuentasCreate prmCuentas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = await cuentasFacade.Create(prmCuentas);
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch (CuentasException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CuentasUpdate prmCuentas)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var response = await cuentasFacade.Update(prmCuentas, id);
                return StatusCode(StatusCodes.Status204NoContent, response);
            }
            catch (CuentasException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await cuentasFacade.Delete(id));
            }
            catch (CuentasException cex)
            {
                return StatusCode(cex.StatusHttpCode, GetMessage(cex.Message));
            };
        }

       
    }
}
