using Actividad02WebApiFacturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.datos
{
    public interface IFactura
    {
        List<Factura> ObtenerFacturas();

        bool Guardar(Factura Ofactura);
        Factura ObtenerId(int id);
    }
}
