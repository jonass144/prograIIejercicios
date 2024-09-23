using Actividad02WebApiFacturacio.datos;
using Actividad02WebApiFacturacion.datos.utilidades;
using Actividad02WebApiFacturacion.dominio;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad02WebApiFacturacion.datos
{
    public class ArticulosRepositoryADO : IArticulos
    {
        private SqlConnection conexion;

        public ArticulosRepositoryADO()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-MJJ3KDQ\SQLEXPRESS;Initial Catalog=facturacion;Integrated Security=True;Trust Server Certificate=True");
        }
        public bool Borrar(int id)
        {
            var parametro = new List<Parametro>();
            parametro.Add(new Parametro("@idarticulo", id));
            int filas = DataHelper.GetInstance().EjecutarSPDML("SP_ELIMINAR_ARTICULO", parametro);
            return filas > 0;
        }

        public bool Editar(Articulos articulo)
        {
            bool result = true;
            string query = "SP_Editar_Articulo";

            try
            {
                if (articulo != null)
                {
                    conexion.Open();
                    var cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idarticulo", articulo.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                    cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                    result = cmd.ExecuteNonQuery() == 1;
                    conexion.Close();
                }
            }
            catch (SqlException sqlexc)
            {
                result = false;
            }
            return result;
        }

        public bool Guardar(Articulos articulo)
        {
            bool result = true;
            string query = "SP_Guardar_Articulo";

            try
            {
                if (articulo != null)
                {
                    conexion.Open();
                    var cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", articulo.Nombre);
                    cmd.Parameters.AddWithValue("@precio", articulo.Precio);
                    result = cmd.ExecuteNonQuery() == 1;
                    conexion.Close();
                }
            }
            catch (SqlException sqlexc)
            {
                result = false;
            }
            return result;
        }

        public List<Articulos> ObtenerArticulos()
        {
            List<Articulos> lstarticulos = new List<Articulos>();
            
            DataTable tabla = DataHelper.GetInstance().EjecutarSPQuery("SP_Obtener_Articulos", null);
            foreach (DataRow filas in tabla.Rows)
            {
                int id = Convert.ToInt32(filas["idarticulo"]);
                string nombre = filas["nombre"].ToString();
                int precio = Convert.ToInt32(filas["precio"]);

                Articulos articulo = new Articulos()
                {
                    Codigo = id,
                    Nombre = nombre,
                    Precio = precio
                };
                lstarticulos.Add(articulo);

            }
            return lstarticulos;
        }

        public Articulos ObtenerId(int id)
        {
            var parametros = new List<Parametro>();
            parametros.Add(new Parametro("@codigo", id));
            DataTable tabla = DataHelper.GetInstance().EjecutarSPQuery("SP_ObtenerArticuloPorId", parametros);

            if (tabla != null && tabla.Rows.Count == 1)
            {
                DataRow row = tabla.Rows[0];
                int codigo = Convert.ToInt32(row["idarticulo"]);
                string nombre = row["nombre"].ToString();
                int precio = Convert.ToInt32(row["precio"]);

                Articulos articulo = new Articulos()
                {
                    Codigo = id,
                    Nombre = nombre,
                    Precio = precio
                };
                return articulo;

            }
            return null;
        }
    
    }
    
}
