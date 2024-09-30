using Actividad05WebApi.Models;
using Actividad05WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Actividad05WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {
        private readonly IServicioService _service;

        public ServiciosController(IServicioService servicioService)
        {
            _service = servicioService;
        }

        [HttpGet("servicios")]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpPost("agregarservicio")]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                if (servicio == null)
                {
                    return BadRequest("ingrese correctamente los datos");
                }
                if (_service.Registrar(servicio))
                    return Ok("servicio ingresado con exito!");
                else
                    return StatusCode(500, "no se ha podido registrar el servicio");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id no valido");
                }
                if (_service.BajaLogica(id))
                {
                    return Ok("servicio eliminado con exito");
                }
                else return StatusCode(500, "no se ha podido eliminar el servicio");
            }
            catch (Exception)
            {
                return StatusCode(500, "eror interno");
            }
        }


        [HttpGet("{nombre}")]
        public IActionResult GetFilter(string nombre)
        {
            try
            {
                if (nombre.IsNullOrEmpty())
                {
                    return NotFound("no se encontro el servicio");
                }
                else
                {
                    return Ok(_service.GetFiltro(nombre));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }

        }


        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] TServicio servicio) 
        {
            try
            {
                if (servicio == null)
                {
                    return BadRequest("ingrese los datos correctamente");
                }
                if (_service.Update(servicio, id))
                {
                    return Ok("servicio actualizado con exito");
                }
                else return BadRequest("no se ha actualizado");
            }
            catch (Exception)
            {
                return StatusCode(500, "eror interno");
            }
        }
         
        
            
    }  
}
