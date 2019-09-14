using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region //Constructores
        /// <summary>
        /// Constructor que inicializa el this.numero en 0.
        /// </summary>
        public Numero()
        {

        }

        /// <summary>
        /// constructor con parametros del tipo double, para asignarle a this.numero.
        /// </summary>
        /// <param name="numero"> variable a asignarle valor. </param>
        public Numero(double numero):this (numero.ToString())
        {

        }

        /// <summary>
        /// constructor con parametro del tipo string.
        /// </summary>
        /// <param name="numero"> variable a asignarle valor. </param>
        public Numero(string numero)
        {
            SetNumero = numero;
        }
        #endregion

        #region //Metodo ValidarNumero
        /// <summary>
        /// Metodo que valida el numero ingresado. convirtiendolo de cadena a tipo double para verificar si es numero.
        /// </summary>
        /// <param name="strNumero"> variable la cual traera una cadena. </param>
        /// <returns></returns>
        private double ValidarNumero(string strNumero)
        {
            double retorno;

            if (!double.TryParse(strNumero, out retorno))
            {
                retorno = 0;
            }

            return retorno;
        }
        #endregion

        #region //ESTO ES UNA PROPIEDAD
        /// <summary>
        /// propiedad para setear un numero y validad el mismo.
        /// </summary>
        private string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region //Convertir binario a decimal
        /// <summary>
        /// Metodo que convierte de binario a decimal
        /// </summary>
        /// <param name="binario"> cadena que recibe como parametro, la cual sera convertida en decimal. </param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string rtn = "";
            bool flag = true;
            char[] miArray = binario.ToCharArray();
            int acumular = 0;

            Array.Reverse(miArray);//doy vuelta el array.

            for(int i = 0; i < miArray.Length; i++)
            {
                if(miArray[i] != '0' && miArray[i] != '1')
                {
                    flag = false;
                    break;
                }
            }

            if (flag)
            {
                for (int i = 0; i < miArray.Length; i++)
                {
                    if (miArray[i] == '1')
                    {
                        acumular += (int)Math.Pow(2, i);
                    }
                }
                rtn = acumular.ToString();
            }
            else
            {
                rtn = "Numero Invalido";
            }
            return rtn;
        }
        #endregion

        #region //Convertir decimal a binario
        /// <summary>
        /// Metodo que convierte de decimal a binario
        /// </summary>
        /// <param name="numero"> parametro del tipo double que sera convertido a binario. </param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            string binario = "";
            int numeroInt = 0;
            int resto;

            numeroInt = (int)numero;

            while (numeroInt > 0)
            {
                resto = (numeroInt % 2);

                if (resto == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }

                numeroInt = numeroInt / 2;
            }
            return binario;

        }
        #endregion

        #region //Convertir decimal a binario
        /// <summary>
        /// Metodo que convierte de decimal a binario
        /// </summary>
        /// <param name="numero"> parametro del tipo string que sera convertido a binario. </param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double num;
            string retorno;
            if(!double.TryParse(numero, out num))
            {
                retorno = "Numero Invalido";
            }
            else
            {
                retorno = DecimalBinario(num);
            }

            return retorno;
        }
        #endregion

        #region //Sobrecarga de operadores
        /// <summary>
        /// metodo de sobrecarga + que realiza una suma.
        /// </summary>
        /// <param name="n1"> primer operando que llega como parametro. </param>
        /// <param name="n2"> segundo operando que llega como parametro. </param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// metodo de sobrecarga * que realiza una multiplicacion.
        /// </summary>
        /// <param name="n1"> primer operando que llega como parametro. </param>
        /// <param name="n2"> segundo operando que llega como parametro. </param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// metodo de sobrecarga / que realiza una division.
        /// </summary>
        /// <param name="n1"> primer operando que llega como parametro. </param>
        /// <param name="n2"> segundo operando que llega como parametro. </param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;

            if(n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }

        /// <summary>
        /// metodo de sobrecarga - que realiza una resta.
        /// </summary>
        /// <param name="n1"> primer operando que llega como parametro. </param>
        /// <param name="n2"> segundo operando que llega como parametro. </param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        #endregion
    }
}
