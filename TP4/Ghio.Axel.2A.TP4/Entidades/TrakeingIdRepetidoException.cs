using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class TrakeingIdRepetidoException : Exception
    {
        public TrakeingIdRepetidoException(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        public TrakeingIdRepetidoException(string mensaje, Exception inner)
        {

        }
    }
}
