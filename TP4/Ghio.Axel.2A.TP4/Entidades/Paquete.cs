using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion

        #region Propiedades
        public string DireccionEntrega { get { return this.direccionEntrega; } set { direccionEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set {this.estado = value; } }
        public string TrackingID { get {return this.trackingID; } set {this.trackingID = value; } }
        #endregion

        #region Metodos
        public void MockCicloVida()
        {              
            while (this.estado != EEstado.Entregado)
            {
                if(this.estado == EEstado.Ingresado)
                {
                    Thread.Sleep(4000);
                    this.estado = EEstado.EnViaje;
                    InformaEstado(this.InformaEstado, EventArgs.Empty);
                }
                else
                {
                    Thread.Sleep(4000);
                    this.estado = EEstado.Entregado;
                    InformaEstado(this.InformaEstado, EventArgs.Empty);
                }
            }
            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool rtn = false;
            if ( p1.trackingID == p2.trackingID)
            {
                rtn = true;
            }
            return rtn;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1==p2);
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.estado = EEstado.Ingresado;
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.MostrarDatos(this) + " - " + this.estado.ToString());
            return sb.ToString();
        }
        #endregion

        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Tipos Anidados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #endregion
    }
}
