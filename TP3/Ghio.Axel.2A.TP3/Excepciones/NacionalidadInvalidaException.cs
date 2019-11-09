using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Metodos

        /// <summary>
        /// Constructor.
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el número de DNI")
        {

        }


        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message)
        {

        }
        #endregion
    }
}
