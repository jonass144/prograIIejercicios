using Actividad02WebApiFacturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacio.datos
{
    public interface IArticulos
    {
        List<Articulos> ObtenerArticulos();

        Articulos ObtenerId(int id);
        bool Guardar(Articulos articulo);
        bool Borrar(int id);

        bool Editar(Articulos articulo);
    }
}
