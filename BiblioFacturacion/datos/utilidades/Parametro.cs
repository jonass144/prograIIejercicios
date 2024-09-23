using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.datos.utilidades
{
    public class Parametro
    {
        public string Nombre {  get; set; }
        public object Valor {  get; set; }

        public Parametro(string nombre, object valor)
        {
            this.Nombre = nombre;
            this.Valor = valor;
        }
    }
}
