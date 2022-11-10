using Entidades;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using Servicios.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiSistemaFactura.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoria categoriaSvc = new CategoriaService();

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await categoriaSvc.GetAllCategorias());
            }
            catch (Exception e)
            {
                throw new Exception($"Error En la peticion: {e.Message}, Status: {StatusCodes.Status400BadRequest}");
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
