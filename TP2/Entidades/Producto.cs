using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {
        #region Enumerado
        /// <summary>
        /// Enumerador.
        /// </summary>
        public enum EMarca { Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico } 
        #endregion

        #region Atributos
        /// <summary>
        /// Atributos
        /// </summary>
        private EMarca marca;
        private string codigoDeBarras;
        private ConsoleColor colorPrimarioEmpaque;
        #endregion


        #region Propiedades
        /// <summary>
        /// Propiedad abstracta que solo toma datos.
        /// </summary>
        protected abstract short CantidadCalorias { get; }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor de producto.
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigo, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigo;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Sobrecarga de ToString()
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p.colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de operador ==
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"> Objeto1 </param>
        /// <param name="v2"> Objeto2 </param>
        /// <returns> Si son iguales retorna true.</returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Sobrecarga de operador !=
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras != v2.codigoDeBarras);
        } 
        #endregion
    }
}
