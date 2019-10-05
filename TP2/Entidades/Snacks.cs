using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructores
        /// <summary>
        /// Constructor con parametros de Sancks;
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {

        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Propiedad que devuelve cantidad de calorias.
        /// Los snacks tienen 104 calorías
        /// </summary>
        protected override short CantidadCalorias { get { return 104; } }
        #endregion

        #region Metodo
        /// <summary>
        /// Metodo sobrescritor para mostrar el producto.
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        } 
        #endregion
    }
}
