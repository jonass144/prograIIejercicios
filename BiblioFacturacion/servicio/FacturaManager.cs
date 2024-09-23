using Actividad02WebApiFacturacion.datos;
using Actividad02WebApiFacturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.servicio
{
    public class FacturaManager
    {
        private IFactura facturaManager;
        public FacturaManager()
        {
            facturaManager = new FacturaRepositoryADO();
        }
        public bool Guardar(Factura Ofactura)
        {
            return facturaManager.Guardar(Ofactura);
        }
        public List<Factura> ObtenerFacturas()
        {
            return facturaManager.ObtenerFacturas();
        }
        public Factura ObtenerPorId(int id)
        {
            return facturaManager.ObtenerId(id);
        }
    }
}
