using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        private Queue<Universidad.EClases> clasesDelDia;
        static Random random;
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que inciara 2 clases random.
        /// </summary>
        private void _randomClase()
        {
            for(int i = 0; i<2; i++)
            {
                clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 4));
            }
        }

        /// <summary>
        /// Metodo para mostrar datos.
        /// </summary>
        /// <returns> Retornara todos los datos.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("CLASE DEL DIA:");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad.
        /// Verificara si un profesor contiene esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns> Retornara si son iguales o no. </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            if (i.clasesDelDia.Contains(clase) == true)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo de operador distinto.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns> retornara si pudo o no verificar. </returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string ParticiparEnClase()
        {
            return "CLASE DEL DIA " + this.clasesDelDia;
        }


        /// <summary>
        /// Constructor sin parametros.
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor statico para inicializar la propiedad random.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClase();
        }


        /// <summary>
        /// Metodo para mostrar los datos.
        /// </summary>
        /// <returns> Retornara todos los daots. </returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion
    }
}
