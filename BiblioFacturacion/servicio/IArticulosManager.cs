using Actividad02WebApiFacturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.servicio
{
    public interface IArticulosManager
    {
        List<Articulos> GetArticulos();

        Articulos GetById(int id);
        bool SaveArticulo(Articulos articulos);
        bool Delete(int id);
        bool Update(Articulos articulos);


    }
}
