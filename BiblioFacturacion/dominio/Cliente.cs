using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; } 
        public DateTime FechaNacimiento { get; set; }

    }
}
