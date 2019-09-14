using System;

namespace Entidades
{
    public static class Calculadora
    {
        #region Metodo Operar
        /// <summary>
        /// Metodo para realizar operacion.
        /// </summary>
        /// <param name="num1"> primer operando </param>
        /// <param name="num2"> segundo operando </param>
        /// <param name="operador"> tipo de operacion que se va a realizar</param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;

            }

            return resultado;
        }
        #endregion

        #region Metodo validar operando.
        /// <summary>
        /// metodo que valida el operando ingresado si el operando no es corrector retorna +
        /// </summary>
        /// <param name="operador"> el tipo operando que recibe. </param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if(operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }
            return operador;
        }
        #endregion
    }
}
