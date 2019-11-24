using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Campos
        Correo correo;
        #endregion

        #region Metodos
        public FrmPpal()
        {
            correo = new Correo();
            InitializeComponent();
            this.Text = "Correo UTN por Axel.Ghio.2A";
        }

        void ActualizarEstado()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();
            foreach (Paquete item in correo.Paquetes)
            {
                if(item.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(item);
                }
                else if(item.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(item);
                }
                else 
                {
                    lstEstadoEntregado.Items.Add(item);
                }
            }
        }

        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.Equals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("Guardar");
            }
        }

        void Paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(Paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstado();
            }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, mtxtTrackingID.Text);
            p.InformaEstado += Paq_InformaEstado;
            try
            {
                correo += p;
            }
            catch(TrakeingIdRepetidoException idRepetido)
            {
                MessageBox.Show("El paquete ya se encuentra en el correo.", idRepetido.Message);
                throw new TrakeingIdRepetidoException("El paquete ya se encuentra en el correo.");
            }
            ActualizarEstado();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void FrmPpal_FormClosing(object sender, EventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
