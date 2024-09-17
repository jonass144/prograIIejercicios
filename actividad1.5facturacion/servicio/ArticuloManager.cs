using actividad1._5facturacion.datos;
using actividad1._5facturacion.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.servicio
{
    public class ArticuloManager
    {
        private IArticulos articulosrepository;

        public ArticuloManager()
        {
                articulosrepository = new ArticulosRepositoryADO();
        }

        public List<Articulos> ObtenerArticulos()
        {
            return articulosrepository.ObtenerArticulos();
        }

        public Articulos ObtenerPorId(int id)
        {
            return articulosrepository.ObtenerId(id);
        }

        public bool GuardarArticulo(Articulos articulo)
        {
            return articulosrepository.Guardar(articulo);
        }
        public bool Borrar(int id)
        {
            return articulosrepository.Borrar(id);
        }
        public bool Actualizar(Articulos articulo)
        {
            return articulosrepository.Editar(articulo);
        }
    }
}
