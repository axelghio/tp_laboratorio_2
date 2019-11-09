using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo con interfas guardar.
        /// Guardara un archivo del tipo xml.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> retornara si pudo guardar o no el archivo. </returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamWriter streamWriter = new StreamWriter(archivo))
                {
                    serializer.Serialize(streamWriter, datos);
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
        /// Metodo leer.
        /// Cargara un archivo del tipo xml.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> retornara si pudo o no cargar el archivo. </returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                StreamReader f = new StreamReader(archivo);
                datos = (T)s.Deserialize(f);
                f.Close();
                retorno = true;
            }

            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
