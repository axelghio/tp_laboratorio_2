using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Interfas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMostrar<T>
    {
        #region Metodos
        /// <summary>
        /// Metodo mostrarDatos.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        string MostrarDatos(IMostrar<T> elemento);
        #endregion
    }
}
