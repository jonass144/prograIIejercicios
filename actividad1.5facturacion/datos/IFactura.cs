using actividad1._5facturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.datos
{
    public interface IFactura
    {
        List<Factura> ObtenerFacturas();

        bool Guardar(Factura Ofactura);
        Factura ObtenerId(int id);
    }
}
