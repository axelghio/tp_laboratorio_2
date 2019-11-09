using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Metodos

        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.")
        {

        }
        #endregion
    }
}
