using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de sobrescritura de equals,
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> devolvera verdadero o falso dependiendo de los parametros que llegen.</returns>
        public override bool Equals(object obj)
        {
            return this.GetType() == obj.GetType();
        }

        /// <summary>
        /// Metodo virtual MostrarDatos.
        /// </summary>
        /// <returns> Devuelve todos los datos de un universitario. </returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("LEGAJO NUMERO: " + this.legajo);
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de metodo de igualacion.
        /// preguntara si los universitarios son iguales.
        /// </summary>
        /// <param name="pg1"> primer parametro a evaluar.</param>
        /// <param name="pg2"> segundo parametro a evaluar.</param>
        /// <returns> Devolvera verdadero si son iguales, de lo contracion falso.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) == true && pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga de metodo distinto.
        /// </summary>
        /// <param name="pg1"> primer parametro a evaluar.</param>
        /// <param name="pg2"> segundo parametro a evaluar.</param>
        /// <returns> reutilizando codigo, devolvera verdadero o falso.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Metodo abstracto que se utilizara con polimorfismo.
        /// </summary>
        protected abstract string ParticiparEnClase();


        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        } 
        #endregion
    }
}
