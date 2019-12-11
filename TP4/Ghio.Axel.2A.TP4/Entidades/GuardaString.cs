using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo statico de extension que guardara un archivo.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool rtn = false;
            try
            {
                using (StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true))
                {
                    file.WriteLine(texto);
                    rtn = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return rtn;
        }
    }
}
