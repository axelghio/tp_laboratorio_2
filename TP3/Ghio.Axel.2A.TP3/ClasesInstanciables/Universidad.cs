using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;
using Excepciones;
using System.Xml.Serialization;
using System.IO;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Tipos Anidados

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}
        #endregion

        #region Campos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }
        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }
        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }
        public Jornada this[int i] { get { return this.jornada[i]; } set { this.jornada[i] = value; } }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para guardar un archivo.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns> devolvera si pudo o no guardarlo.</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> t = new Xml<Universidad>();
            return t.Guardar(AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml", uni);
        }

        /// <summary>
        /// Metodo para leer un archivo.
        /// </summary>
        /// <returns> devolvera si pudo o no cargar el archivo. </returns>
        public Universidad Leer()
        {
            Xml<Universidad> t = new Xml<Universidad>();
            Universidad u = new Universidad();
            t.Leer(AppDomain.CurrentDomain.BaseDirectory + "\\Universidad.xml", out u);
            return u;
        }

        /// <summary>
        /// Metodo utilizado para mostrar todos los datos de la universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns> retornara una cadena con toda la informacion. </returns>
        static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach(Jornada item in uni.jornada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Metodo de igualacion.
        /// igualara una universidad y un alumno.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns> retornara si son iguales. </returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno item in g.Alumnos)
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
        /// Metodo de igualacion.
        /// igualara una universidad y un profesor.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns> retornara si son iguales. </returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach(Profesor item in g.Instructores)
            if (item == i)
            {
                retorno = true;
                break;
            }
            return retorno;
        }

        /// <summary>
        /// Metodo de igualacion.
        /// igualara una universidad y una clase.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> retornara si son iguales. </returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            bool flag = false;

            foreach (Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    flag = true;
                    retorno = item;
                    break;
                }
            }
            if(flag == false)
            {
                throw new SinProfesorException();
            }
            return retorno;
        }

        /// <summary>
        /// Metodo de adicion.
        /// Agregara una clase a una universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> retornara la universidad con la clase agragada. </returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor aux = null;
            aux = (u == clase);
            Jornada j = new Jornada(clase, aux);

            foreach (Alumno item in u.Alumnos)
            {
                if(item == clase)
                {
                    j += item;
                }
            }
            u.jornada.Add(j);
            return u;
        }

        /// <summary>
        /// Metodo de adicion.
        /// Agregara un alumno a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns> retornara la universidad con el alumno agregado.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
               throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Metodo de adicion.
        /// Agregara un profesor a la universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns> retornara la universidad con el profesor agregado.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Metodo distinto.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns> retornara reutilizando codigo del metodo igualacion un booleano. </returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Metodo distinto.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns> retornara reutilizando codigo del metodo igualacion un booleano. </returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        ///  Metodo distinto.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns> retornada el primer profesor que no puede dar esa clase. </returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor aux = null;
            foreach (Profesor item in u.Instructores)
            {
                if(item != clase)
                {
                    aux = item;
                    break;
                }
            }
            return aux;
        }

        /// <summary>
        /// Hace publico el metodo mostrardatos.
        /// </summary>
        /// <returns> retornara todos los datos de la universidad. </returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        /// <summary>
        /// Constructor con parametros.
        /// Inicializara las listas.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion
    }
}
