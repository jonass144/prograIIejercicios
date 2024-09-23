using Actividad02WebApiFacturacio.datos;
using Actividad02WebApiFacturacion.datos;
using Actividad02WebApiFacturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.servicio
{
    public class ArticuloManager : IArticulosManager
    {
        private IArticulos Articulos;

        public ArticuloManager()
        {
                Articulos = new ArticulosRepositoryADO();
        }

        public List<Articulos> GetArticulos()
        {
            return Articulos.ObtenerArticulos();
        }

        public Articulos GetById(int id)
        {
            return Articulos.ObtenerId(id);
        }

        public bool SaveArticulo(Articulos articulos)
        {
            return Articulos.Guardar(articulos);
        }

        public bool Delete(int id)
        {
            return Articulos.Borrar(id);
        }

        public bool Update(Articulos articulos)
        {
            return Articulos.Editar(articulos);
        }
    }
}
