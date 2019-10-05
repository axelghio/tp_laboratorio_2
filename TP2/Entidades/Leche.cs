using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        #region Enumerador y atributo
        /// <summary>
        /// Enumerador.
        /// </summary>
        public enum ETipo { Entera, Descremada }

        /// <summary>
        /// Atributo
        /// </summary>
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor con parametros de Leche, por defecto TIPO será ENTERA.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(Producto.EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }

        /// <summary>
        /// Constructor con parametros de Leche, +1 parametro de ETIPO.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(Producto.EMarca marca, string codigo, ConsoleColor color, ETipo tipo) : this(marca, codigo, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad que nos retorna las calorias del producto. Las leches tienen 20 calorías.
        /// </summary>
        protected override short CantidadCalorias { get { return 20; } }
        #endregion

        #region Metodo
        /// <summary>
        /// Metodo sobrescritor para mostrar el producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendFormat("TIPO : {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
