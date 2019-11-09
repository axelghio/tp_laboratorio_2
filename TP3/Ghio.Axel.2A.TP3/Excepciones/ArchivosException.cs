
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        #region Metodos

        /// <summary>
        /// Constructor que recibe una exepcion.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base(innerException.Message)
        {

        } 
        #endregion
    }
}
