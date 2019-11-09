using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Tipos anidados

        public enum EEstadoCuenta { AlDia, Deudor, Becado}
        #endregion

        #region Campos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Metodos

        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id,nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Metodo heredado para mostrar datos.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Metodo de igualacion de un alumno y una clase.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns> Retorna si se pudo o no validar. </returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Metodo distinto.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns> Retorna si se pudo o no validar. </returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Metodo para saber que clase toma el alumno.
        /// </summary>
        /// <returns> Retorna la clase. </returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma;
        }

        /// <summary>
        /// Metodo de sobrescritura del ToString.
        /// </summary>
        /// <returns> Retornara los datos del alumno. </returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

    }
}
