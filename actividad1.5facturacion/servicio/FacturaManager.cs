using actividad1._5facturacion.datos;
using actividad1._5facturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.servicio
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
