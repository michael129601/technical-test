using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaNTTDATA.ApiContracts;
using PruebaTecnicaNTTDATA.Core.Facades;
using PruebaTecnicaNTTDATA.Entity.Connector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnicaNTTDATA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerGeneric
    {

        private ClienteFacade facadeCliente;

        public ClientesController(ApplicationDBContext prmContext) : base(prmContext)
        {
            facadeCliente = new ClienteFacade(prmContext);
        }

        // GET: api/<CuentasController>
        [HttpGet]
        public async Task<object> Get()
        {
            var response =  await facadeCliente.GetAll();
            return Ok(response);
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var response = await facadeCliente.GetById(id);
           
            return response == null ? StatusCode(StatusCodes.Status404NotFound, responseNotFound()) : Ok(response);
        }

        // POST api/<CuentasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteCreate prmCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await facadeCliente.Create(prmCliente);
            return StatusCode(StatusCodes.Status201Created,response);

        }

        // PUT api/<CuentasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteUpdate cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await facadeCliente.Update(cliente, id);
            return response == null ? StatusCode(StatusCodes.Status404NotFound, responseNotFound()) :
                StatusCode(StatusCodes.Status204NoContent);


        }

        // DELETE api/<CuentasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int response = await facadeCliente.Delete(id);
            if (response == -1)
                return StatusCode(StatusCodes.Status404NotFound, responseNotFound());

            return StatusCode(StatusCodes.Status204NoContent);
        }

        private object responseNotFound()
        {
            return new  {
                message = "Cliente no encontrado"
            };
        }
    }
}
