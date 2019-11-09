using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Campos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos { get {return this.alumnos; } set { this.alumnos = value; } }
        public Universidad.EClases Clase { get { return this.clase; } set { this.clase = value; } }
        public Profesor Instructor { get {return this.instructor; } set { this.instructor = value; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para guardar un archivo.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns> retornara si pudo o no guardar el archivo. </returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            return t.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Constructor que inicializara la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor con parametros.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Metodo leer
        /// </summary>
        /// <returns> retornara si pudo o no cargar el archivo.</returns>
        public string Leer()
        {
            Texto t = new Texto();
            string texto = "";
            t.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\jornada.txt", out texto);
            return texto;
        }

        /// <summary>
        /// Sobrecarga de metodo igualdad.
        /// Preguntara si se encuentra el alumno en la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns> retornara si se encuentra ese alumno. </returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in j.Alumnos)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga de metodo distinto.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga de metodo adicion.
        /// Agregara un alumno a la jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns> retornara esa jornada con el alumno agregado. </returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Mostrara todos los datos de la jornada.
        /// </summary>
        /// <returns> retornara una cadena con toda la informacion. </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CLASE DE " + this.Clase.ToString());
            sb.AppendLine(" POR " + this.Instructor.ToString());
            sb.AppendLine("Alumnos:");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<-------------------------------------------->");
            return sb.ToString();
            
        }
        #endregion

    }
}
