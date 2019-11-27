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
        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="mensaje"></param>
        public TrakeingIdRepetidoException(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        /// <summary>
        /// Segundo constructor con parametros.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="inner"></param>
        public TrakeingIdRepetidoException(string mensaje, Exception inner)
        {

        }
    }
}
