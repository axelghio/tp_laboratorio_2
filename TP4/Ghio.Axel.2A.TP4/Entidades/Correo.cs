using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        #region campos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Propiedades
        public List<Paquete> Paquetes { get {return this.paquetes; } set {this.paquetes = value; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Constructor por defaul que inicializa listas.
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// metodo FinEntregas, detendra los hilos.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in mockPaquetes)
            {
                item.Abort();
            }
        }

        /// <summary>
        /// Metodo que mostrara los datos del objeto a manipular.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string aux = "";
            List<Paquete> p = (List<Paquete>)((Correo)elementos).paquetes;
            foreach (Paquete item in p)
            {
                 aux += string.Format("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }

            return aux;
        }

        /// <summary>
        /// Operador de sobre carga de adicion agregara paquetes a una lista.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool flag = false;

            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    flag = true;
                    throw new TrakeingIdRepetidoException("Paquete ID repetido. Por favor ingresa otro ID.");
                }
            }

            if (flag != true)
            {
                c.paquetes.Add(p);
                Thread h = new Thread(p.MockCicloVida);
                c.mockPaquetes.Add(h);
                h.Start();
            }
            return c;
        }
        #endregion
    }
}
