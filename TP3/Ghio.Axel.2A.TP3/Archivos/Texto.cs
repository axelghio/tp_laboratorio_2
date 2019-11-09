using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region Metodos

        /// <summary>
        /// Metodo con interfas guardar.
        /// Guardara un archivo del tipo txt.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="dato"></param>
        /// <returns> retornara si pudo o no guardar el archivo. </returns>
        public bool Guardar(string archivo, string dato)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter jornadaTxt = new StreamWriter(archivo))
                {
                    jornadaTxt.WriteLine(dato);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Metodo con interfas leer.
        /// Cargara un archivo del tipo txt.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> retornara si pudo o no cargar el archivo. </returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamReader jornadaTxt = new StreamReader(archivo))
                {
                    datos = jornadaTxt.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
        #endregion
    }
}
