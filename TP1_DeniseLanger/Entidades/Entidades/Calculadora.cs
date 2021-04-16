using System;

namespace Entidades
{
    public  class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido sea +, -, / o *. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>Retorna el operador si es correcto. En caso contrario devuelve por default "+" </returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return operador.ToString();
            }
            else
            {
                return "+";
            }
        }

        /// <summary>
        /// Valida y realiza la operacion solicitada entre 2 numeros. En caso contrario, retorna 0 por default.
        /// </summary>
        /// <param name="num1">Primer numero para realizar la operacion</param>
        /// <param name="num2">Segundo numero para realizar la operacion</param>
        /// <param name="operador">Operador ya validado para realizar el calculo</param>
        /// <returns>El resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;

            switch (ValidarOperador(Convert.ToChar(operador)))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }
            return resultado;
        }
    }
}
