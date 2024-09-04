using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.datos.utilidades
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
