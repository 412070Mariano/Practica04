using Microsoft.AspNetCore.Mvc;
using Problema2_7Back.Data.Entities;
using Problema2_7Back.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProblema2_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private IServicioRepository _Repository;

        public ServicioController(IServicioRepository repository)
        {
            _Repository = repository;
        }

        // GET: api/<ServicioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_Repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(500, "¡Ocurrio un error interno!");
            }

        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_Repository.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "¡Ocurrio un error interno!");
            }
        }

        //[HttpGet("filtro/{nombre}")]
        //public IActionResult GetByFilter(string nombre)
        //{

        //}


        // POST api/<ServicioController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio value)
        {
            try
            {
                if(IsValid(value))
                {
                    _Repository.Create(value);
                    return Ok("¡Servicio creado exitosamente!");
                }
                else
                {
                    return BadRequest("Los datos estaban incorrectos o incompletos");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "¡Ocurrio un error interno, no se pudo crear!");
            }
        }

        private bool IsValid (TServicio value)
        {
            return value.Id != 0
                && !string.IsNullOrEmpty(value.Nombre)
                && !string.IsNullOrEmpty(value.EnPromocion)
                && value.Costo != 0;
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TServicio value)
        {

            if (value == null || id!=value.Id)
            {
                return BadRequest("El número de servicio no coincide.");
            }

            try
            {
                var servicioExistente = _Repository.GetById(id); // Método para obtener el libro por ID
                if (servicioExistente == null)
                {
                    return NotFound("Servicio no encontrado.");
                }
                servicioExistente.Id = value.Id;
                servicioExistente.Nombre = value.Nombre;
                servicioExistente.Costo = value.Costo;
                servicioExistente.EnPromocion = value.EnPromocion;

                _Repository.Update(servicioExistente);
                return Ok("Servicio actualizado");
            }
            catch (Exception)
            {
                return StatusCode(500, "¡Ocurrio un error interno!");
            }

        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _Repository.Delete(id);
                return Ok($"Servicio borrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "¡Ocurrio un error interno!");
            }

        }
    }
}
