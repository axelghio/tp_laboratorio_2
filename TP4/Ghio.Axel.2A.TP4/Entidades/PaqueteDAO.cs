using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        static SqlCommand comando;
        static SqlConnection conexion;
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor statico inicializara las conexiones con el sql
        /// </summary>
        static PaqueteDAO()
        {
            comando = new SqlCommand();
            conexion = new SqlConnection(Properties.Settings.Default.connect);
        }

        /// <summary>
        /// Metodo insertar.
        /// Insertara objetos en la base de datos.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool rtn = false;

            comando = new SqlCommand();
            comando.CommandText = "INSERT INTO [correo-sp-2017].[dbo].[Paquetes] ([direccionEntrega],[trackingID],[alumno])" + " VALUES (@direccion, @tracking, @alumno)";
            comando.Parameters.AddWithValue("@direccion", p.DireccionEntrega);
            comando.Parameters.AddWithValue("@tracking", p.TrackingID);
            comando.Parameters.AddWithValue("@alumno", "Ghio Axel");

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                if (comando.ExecuteNonQuery() > 0)
                {
                    rtn = true;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                conexion.Close();
            }
            return rtn;
            #endregion
        }
    }
}
