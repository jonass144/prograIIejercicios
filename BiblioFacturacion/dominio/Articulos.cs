using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.dominio
{
    public class Articulos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public Articulos()
        {
            Codigo = 0;
            Nombre = string.Empty;
            Precio = 0;
        }

        public Articulos(int codigo, string nombre, int precio)
        {
            Codigo = this.Codigo;
            Nombre = this.Nombre;
            Precio=this.Precio;
        }

    
    


        public override string ToString()
        {
            return Nombre.ToString();
        }
    }
}
