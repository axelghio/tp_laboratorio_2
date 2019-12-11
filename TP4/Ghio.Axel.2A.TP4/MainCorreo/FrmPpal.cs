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

        /// <summary>
        /// Constructor defaul.
        /// </summary>
        public FrmPpal()
        {
            correo = new Correo();
            InitializeComponent();
            this.Text = "Correo UTN por Axel.Ghio.2A";
        }

        /// <summary>
        /// Metodo que actualiza el estado del paquete.
        /// </summary>
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

        /// <summary>
        /// Metodo que muestra informacion de un paquete.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.Equals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        /// <summary>
        /// Muestra estado de un paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Boton para agregar un paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(this.txtDireccion.Text, mtxtTrackingID.Text);
            p.InformaEstado += Paq_InformaEstado;
            try
            {
                correo += p;
                ActualizarEstado();
            }
            catch(TrakeingIdRepetidoException repetido)
            {
                MessageBox.Show(repetido.Message);
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
        }

        /// <summary>
        /// Boton para mostrar todos los paquetes en una lista.
        /// con su estado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Metodo para cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, EventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// SubMenu en el listado fin de entregas para mostrar 1 paquete en particular.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
