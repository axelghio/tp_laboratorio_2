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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor de la clase form.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.Items.Add("/");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");

        }

        /// <summary>
        /// Metodo de carga de formulari.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Text = "Calculadora de Axel Ghio del curso 2ºA";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "";
            this.cmbOperador.Text = "/";
            this.txtNumero2.Text = "";
            this.btnOperar.Text = "Operar";
            this.btnLimpiar.Text = "Limpiar";
            this.btnCerrar.Text = "Cerrar";
            this.btnConvertirABinario.Text = "Convertir A Binario";
            this.btnConvertirADecimal.Text = "Convertir A Decimal";
        }

        /// <summary>
        /// metodo de boton al hacer click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        /// <summary>
        /// metodo de boton limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// metodo de boton cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// metodo de boton convertir a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// metodo de boton convertir a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero num = new Numero();
            this.lblResultado.Text = num.BinarioDecimal(this.lblResultado.Text);
        }

        /// <summary>
        /// metodo vacio limpiar.
        /// </summary>
        private void Limpiar()
        {
            this.lblResultado.Text = "0";
            this.txtNumero1.Text = "";
            this.cmbOperador.Text = "/";
            this.txtNumero2.Text = "";
        }

        /// <summary>
        /// metodo operar que realiza operaciones mediante la toma de datos con el forms.
        /// </summary>
        /// <param name="numero1"> parametro tipo string numero. </param>
        /// <param name="numero2"> parametro tipo string numero. </param>
        /// <param name="operador"> parametro tipo string operador. </param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }
    }
}
