﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Actividad02WebApiFacturacion.datos.utilidades
{
    public class DataHelper
    {
        private static DataHelper instancia;
        private SqlConnection conexion;

        private DataHelper()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-MJJ3KDQ\SQLEXPRESS;Initial Catalog=facturacion;Integrated Security=True;Trust Server Certificate=True");
           
        }

        public static DataHelper GetInstance()
        {
            if (instancia == null)
            {
                instancia = new DataHelper();
               
            }
            return instancia;
        }

        public DataTable EjecutarSPQuery(string sp, List<Parametro> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Open();
                var cmd = new SqlCommand(sp, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = sp;
                if(parametros != null)
                {
                    foreach (var parametro in parametros)
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);                 
                }
                dt.Load(cmd.ExecuteReader());
                conexion.Close();    
            }
            catch(SqlException)
            {
                dt = null;
            }
            return dt;
        }

        public int EjecutarSPDML(string sp, List<Parametro> parametros)
        {
            int filas;
            try
            {
                conexion.Open();
                var cmd = new SqlCommand(sp, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros != null)
                {
                    foreach (var parametro in parametros)
                        cmd.Parameters.AddWithValue(parametro.Nombre, parametro.Valor);


                }
                filas = cmd.ExecuteNonQuery();
                conexion.Close();

            }
            catch (SqlException)
            {
                {
                    filas = 0;
                }
            }
            return filas;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }

    }
}
