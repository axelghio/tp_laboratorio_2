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
            try
            {
                conexion.Open();
                comando = new SqlCommand();
                string query = "INSERT INTO dbo.Paquetes (direccionEntrega, trackingID, alumno) VALUES ('" + p.DireccionEntrega + "', '" + p.TrackingID + "','Axel')";
                comando.Connection = conexion;
                comando.CommandText = query;
                rtn = true;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message, "La configuracion con el sql server es invalida.");
            }
            catch(InvalidOperationException con)
            {
                MessageBox.Show(con.Message, "No se puede establecer una conexión.");
            }
            finally
            {
                conexion.Close();
            }

            return rtn;
        }
        #endregion
    }
}
