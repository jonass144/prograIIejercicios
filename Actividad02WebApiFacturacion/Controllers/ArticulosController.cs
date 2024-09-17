using actividad1._5facturacion.datos;
using actividad1._5facturacion.dominio;
using actividad1._5facturacion.servicio;
using Microsoft.AspNetCore.Mvc;


namespace Actividad02WebApiFacturacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {




    private IArticulosManager service_;
        public ArticulosController()
        {
            service_ = new ArticuloManager();
        }
       
        [HttpGet("Articulos")]
        public IActionResult Get()
        {

            return Ok(service_.GetArticulos());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Articulos articulo)
        {
            try
            {
                if (articulo == null)
                {
                    return BadRequest("se esperaba un articulo");
                }
                if (service_.SaveArticulo(articulo))
                    return Ok("articulo guardado con exito");
                else
                    return StatusCode(500, "no se pudo guardar el articulo");
                
            }
            catch (Exception)
            {
                return StatusCode(500, "error interno ");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest("no se encontro articulo");
                }
                if (service_.Delete(id))
                    return Ok("articulo eliminado");
                else return StatusCode(500, "eliminacion fallida vuelva a intentar");

            }
            catch (Exception)
            {
                return StatusCode(500, "error interno");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulos articulo)
        {
            try
            {
                if (articulo == null)
                    return BadRequest("se esperaba un articulo");
                if (service_.Update(articulo))
                    return Ok("articulo actualizado con exito");
                else
                    return StatusCode(500, "no se actualizo el articulo");
            }
            catch(Exception)
            {
                return StatusCode(500, "error interno");
            }
         

        }
    }
}
