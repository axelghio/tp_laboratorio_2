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
        public static bool Guardar(this string texto, string archivo)
        {
            bool rtn = false;
            try
            {
                using (StreamWriter arch = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt", true))
                {
                    arch.WriteLine(texto);
                    rtn = true;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return rtn;
        }
    }
}
