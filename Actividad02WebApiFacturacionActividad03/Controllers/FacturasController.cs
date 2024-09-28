
using Actividad02WebApiFacturacion.dominio;
using Actividad02WebApiFacturacion.servicio;
using BiblioFacturacion.servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actividad02WebApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : Controller
    {
        private IFacturaManager _servicio;
        public FacturasController()
        {
            _servicio = new FacturaManager();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_servicio.GetFacturas());
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            try
            {
                if(factura == null)
                {
                    return BadRequest("se esperaba una factura");
                }
                if (_servicio.SaveFactura(factura))
                    return Ok("factura guardada con exito");
                else
                    return StatusCode(500,"la factura no se guardo, intetelo de nuevo");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");

            }
        }



    }
}
