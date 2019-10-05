using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Constructor
        /// <summary>
        /// Constructor con parametros de Dulce.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Dulce(Producto.EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad. Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias { get { return 80; } }
        #endregion

        #region Metodo
        /// <summary>
        /// Metodo sobrescritor para mostrar el producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
