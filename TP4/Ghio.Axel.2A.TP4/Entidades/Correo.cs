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
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread item in mockPaquetes)
            {
                item.Abort();
            }
        }

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

        public static Correo operator +(Correo c, Paquete p)
        {
            bool aux = false;

            if(c.paquetes.Count > 0)
            {
                foreach (Paquete item in c.paquetes)
                {
                    if (item != p)
                    {
                        c.paquetes.Add(p);
                        Thread h = new Thread(p.MockCicloVida);
                        c.mockPaquetes.Add(h);
                        h.Start();
                        break;
                    }
                    else
                    {
                        aux = true;
                    }
                }

            }
            else
            {
                c.paquetes.Add(p);
                Thread h = new Thread(p.MockCicloVida);
                c.mockPaquetes.Add(h);
                h.Start();
            }
            
            if(aux == true)
            {
                throw new TrakeingIdRepetidoException("El paquete ya se encuentra en el correo.");
            }
            return c;
        }
        #endregion
    }
}
