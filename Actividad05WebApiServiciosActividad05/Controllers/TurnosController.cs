using Actividad05WebApi.Models;
using Actividad05WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividad05WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _service;
        public TurnosController(ITurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
          
        }
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turno)
        {
            try
            {
                if (turno == null)
                {
                    return BadRequest("ingrese correctamente los datos");
                }
                if (_service.Save(turno))
                    return Ok("servicio ingresado con exito!");
                else
                    return StatusCode(500, "no se ha podido registrar el servicio");
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] TTurno turno)
        {
            try
            {
                if (_service.Update(turno, id))
                {
                    return Ok("turno actualizado");
                }
                else return NotFound("turno no encontrado");
            }
            catch
            {
                return StatusCode(500, "error interno");
            }
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int id)
        {
            try
            {
                if (_service.Delete(id))
                {
                    return Ok("turno cancelado");
                }
                else return NotFound("turno no encontrado");

            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpGet("filtro")]
        public IActionResult Get([FromQuery] string cliente, [FromQuery] string fecha)
        {
            try
            {
                return Ok(_service.FindByClientDate(cliente, fecha));
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
        }
    }
}
