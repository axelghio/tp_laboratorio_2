using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Campos

        private string mensajeBase;
        #endregion

        #region Metodos

        /// <summary>
        /// Constructor base.
        /// </summary>
        public DniInvalidoException() : base("DNI INVALIDO")
        {
            
        }

        /// <summary>
        /// Constructor con parametro. que recibe una exepcion.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e) : base(e.Message)
        {

        }

        /// <summary>
        /// Constructor con parametro que recibe una cadena.
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message)
        { 

        }

        /// <summary>
        /// Constructor con parametros que recibe una cadena y una exepcion.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e): base(message, e)
        {
            this.mensajeBase = message;
        }
        #endregion
    }
}
