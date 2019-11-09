using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region TiposAnidados
        public enum ENacionalidad { Argentino, Extranjero }
        #endregion

        #region Campos
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades

        public string Apellido { get { return ValidarNombreApellido(this.apellido); } set { this.apellido = ValidarNombreApellido(value); } }
        
        public int DNI { get { return ValidarDni(this.Nacionalidad, this.dni); } set { this.dni = ValidarDni(this.Nacionalidad, value); } }

        public ENacionalidad Nacionalidad { get { return this.nacionalidad; } set { this.nacionalidad = value; } }

        public string Nombre { get { return ValidarNombreApellido(this.nombre); } set { this.nombre = ValidarNombreApellido(value); } }

        public string StringToDNI { get { return this.dni.ToString(); } set { this.dni = Convert.ToInt32(value); } }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo constructor sin parametros.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Metodo constructor con paraemtros.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Metodo constructor con paraemtros.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Metodo constructor con paraemtros.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// sobreescritura del metodo toString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: {0}, {1}", this.Apellido, this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: {0}", this.Nacionalidad);
            sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Metodo de validacion de dni.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Retorna el numero de dni validado. </returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            return ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Metodo de validacion de dni.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns> Retorna el numero de dni validado. </returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = 0;
            if(dato.Length >= 9)
            {
                throw new DniInvalidoException("Fuera de rango de digitos para DNI.");
            }
            else if (Regex.IsMatch(dato, @"^[0-9]+$") == false)
            {
                throw new DniInvalidoException("Digitos Invalidos.");
            }
            else if (nacionalidad == ENacionalidad.Argentino && Convert.ToInt32(dato) >= 1 && Convert.ToInt32(dato) <= 89999999)
            {
                retorno = Convert.ToInt32(dato);
            }
            else if (nacionalidad == ENacionalidad.Extranjero && Convert.ToInt32(dato) >= 90000000 && Convert.ToInt32(dato) <= 99999999)
            {
                retorno = Convert.ToInt32(dato);
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
            return retorno;
        }

        /// <summary>
        /// Metodo de validacion del nombre y el apellido.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns> Retornara el valor ingresado una vez validado. </returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = "";

            if (Regex.IsMatch(dato, @"^[a-zA-Z]+$") == true)
            {
                retorno = dato;
            }

            return retorno;
        }

        #endregion
    }
}
