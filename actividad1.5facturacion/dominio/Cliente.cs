﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; } 
        public DateTime FechaNacimiento { get; set; }

    }
}
