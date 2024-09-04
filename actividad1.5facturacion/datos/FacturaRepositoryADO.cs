using actividad1._5facturacion.datos.utilidades;
using actividad1._5facturacion.dominio;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actividad1._5facturacion.datos
{
    public class FacturaRepositoryADO : IFactura
    {
        public bool Guardar(Factura Ofactura)
        {
            bool result = true;
            SqlConnection conex = null;
            SqlTransaction trans = null;
            try
            {
                conex = DataHelper.GetInstance().GetConnection();
                conex.Open();
                trans = conex.BeginTransaction();
                var cmd = new SqlCommand("SP_InsertarFactura", conex, trans);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@formapago", Ofactura.FormasPago);
                cmd.Parameters.AddWithValue("@cliente", Ofactura.Cliente);

                SqlParameter parametro = new SqlParameter("@nrofactura", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();

                int facturaId = (int)parametro.Value;
                int detalleId = 1;
                foreach ( var detalle in Ofactura.Detalles)
                {
                    var cmdDetalle = new SqlCommand("SP_InsertarDetalle",conex, trans);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@iddetalle", detalleId);
                    cmdDetalle.Parameters.AddWithValue("@nrofactura", facturaId);
                    cmdDetalle.Parameters.AddWithValue("@idarticulo", detalle.Articulo.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    detalleId++;    
                }              

                trans.Commit();
            }
            catch (SqlException)
            {
                if(trans != null)
                    trans.Rollback();
               result = false;
            }
            finally
            {
                if(conex != null && conex.State==ConnectionState.Open)
                {
                    conex.Close();
                }
            }

            return result;
        }

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> lstfac = new List<Factura>();
            Factura Ofactura = null;
            var helper = DataHelper.GetInstance();
            var tabla = helper.EjecutarSPQuery("SP_ObtenerFacturas", null);
            foreach (DataRow fila in tabla.Rows)
            {
                if (Ofactura == null || Ofactura.NroFactura != Convert.ToInt32(fila["nrofactura"].ToString()))
                {
                    Ofactura = new Factura();
                    Ofactura.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
                    Ofactura.FormasPago.Codigo = Convert.ToInt32(fila["formaspago"].ToString());
                    Ofactura.Cliente.Id = Convert.ToInt32(fila["cliente"].ToString());
                    Ofactura.NroFactura = Convert.ToInt32(fila["nrofactura"].ToString());
                    lstfac.Add(Ofactura);
                }      
            }
            return lstfac;
        }

        

        public Factura ObtenerId(int id)
        {
            Factura? Ofactura = null;
            var helper = DataHelper.GetInstance();
            var parametro = new Parametro("@nrofactura", id);
            var parametros = new List<Parametro>();
            parametros.Add(parametro);

            var tabla = helper.EjecutarSPQuery("SP_ObtenerFacturasPorId", parametros);
            foreach (DataRow fila in tabla.Rows)
            {
                if(Ofactura == null)
                {
                    Ofactura = new Factura();
                    Ofactura.NroFactura = Convert.ToInt32(fila["nrofactura"].ToString());
                    Ofactura.Fecha = Convert.ToDateTime(fila["fecha"].ToString());
                    Ofactura.FormasPago.Codigo = Convert.ToInt32(fila["formaspago"].ToString());
                    Ofactura.Cliente.Id = Convert.ToInt32(fila["cliente"].ToString());
                }
            }
            return Ofactura;



        }
    }
}
