using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.dominio
{
    public class DetalleFactura
    {
        
        public Articulos Articulo { get; set; }
        public int Cantidad { get; set; }

        public float Subtotal()
        {
            return Cantidad * Articulo.Precio; 
        }

    }
}
