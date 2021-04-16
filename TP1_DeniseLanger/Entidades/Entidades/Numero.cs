using System;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor con 1 parametro del tipo double
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero) : this()
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor con 1 parametro del tipo string
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero) : this()
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Getter del atributo numero
        /// </summary>
        /// <returns>Devuelve el valor de this.numero</returns>
        public double GetNumero()
        {
            return this.numero;
        }

        /// <summary>
        /// Propiedad para settear el valor del atributo número, validado previamente. 
        /// </summary>
        /// <returns></returns>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Comprueba que el valor recibido es numerico y en caso de ser así, lo retorna como double. 
        /// En caso contrario, retorna 0
        /// </summary>
        /// <param name="strNumero">Valor a validar</param>
        /// <returns>Numero ya validado (tipo double) o 0 en caso de no ser un valor numerico </returns>
        private double ValidarNumero(string strNumero)
        {
            if (Double.TryParse(strNumero, out double numeroValido) && (!Double.IsNaN(numeroValido)))
                return numeroValido;
            else
                return 0;
        }
        /// <summary>
        /// Valida que el string sea un numero binario (solo tenga 0 y 1)
        /// </summary>
        /// <param name="binario">String que contiene el valor binario a validar </param>
        /// <returns>Devuele true si es un numero binario o false en caso contrario</returns>
        private bool EsBinario(string binario)
        {
            char[] arrayBinario = binario.ToCharArray();
            bool resultado = true;

            for (long i = 0; i < arrayBinario.Length; i++)
            {
                if (arrayBinario[i] != '1' && arrayBinario[i] != '0')
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el string corresponda a un numero binario y en caso de ser posible, lo convierte a decimal. 
        /// </summary>
        /// <param name="binario">String del numero binario a validar y convertir a decimal</param>
        /// <returns>El binario convertido a decimal o en caso contrario devuelve "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
            string resultado;

            if (EsBinario(binario))
            {
                char[] arrayBinario = binario.ToCharArray();
                Array.Reverse(arrayBinario);

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')
                        numeroDecimal += (int)Math.Pow(2, i);
                }
                resultado = numeroDecimal.ToString();
            }
            else
            {
                resultado = "Valor inválido";
            }
            return resultado;
        }

        /// <summary>
        /// Valida que el string corresponda a un numero decimal y en caso de ser posible, lo convierte a binario. 
        /// </summary>
        /// <param name="numero">String del numero decimal a validar y convertir a binario</param>
        /// <returns>El decimal convertido a binario o en caso contrario devuelve "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            string numeroBinario = "";
            char[] numeroBinarioCorrecto;

            if (int.TryParse(numero, out int intNumero))
            {
                if (numero.Equals(double.MinValue.ToString()))
                {
                    return "Valor Invalido";
                }
                else
                {
                    intNumero = Math.Abs(intNumero);
                    while (intNumero > 0)
                    {
                        numeroBinario += intNumero % 2;
                        intNumero /= 2;
                    }
                }
            }
            numeroBinarioCorrecto = numeroBinario.ToCharArray();
            Array.Reverse(numeroBinarioCorrecto);
            return new string(numeroBinarioCorrecto);
        }

        /// <summary>
        /// Valida que numero corresponda a un decimal y en caso de ser posible, lo convierte a binario. 
        /// </summary>
        /// <param name="numero">Numero decimal a validar y convertir a binario</param>
        /// <returns>El decimal convertido a binario o en caso contrario devuelve "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }

        #region Operadores
        /// <summary>
        /// Sobrecarga de operador -
        /// </summary>
        /// <param name="num1">Objeto del tipo Numero</param>
        /// <param name="num2">Objeto del tipo Numero</param>
        /// <returns>El valor de la resta entre ambos numeros </returns>
        public static double operator -(Numero num1, Numero num2)
        {
            return num1.GetNumero() - num2.GetNumero();
        }

        /// <summary>
        /// Sobrecarga de operador *
        /// </summary>
        /// <param name="num1">Objeto del tipo Numero</param>
        /// <param name="num2">Objeto del tipo Numero</param>
        /// <returns>El valor de la multiplicacion entre ambos numeros </returns>
        public static double operator *(Numero num1, Numero num2)
        {
            return num1.GetNumero() * num2.GetNumero();
        }

        /// <summary>
        /// Sobrecarga de operador /
        /// </summary>
        /// <param name="num1">Objeto del tipo Numero</param>
        /// <param name="num2">Objeto del tipo Numero</param>
        /// <returns>El valor de la division entre ambos numeros </returns>
        public static double operator /(Numero num1, Numero num2)
        {
            if (num2.GetNumero() != 0)
                return num1.GetNumero() / num2.GetNumero();
            else
                return double.MinValue;
        }

        /// <summary>
        /// Sobrecarga de operador +
        /// </summary>
        /// <param name="num1">Objeto del tipo Numero</param>
        /// <param name="num2">Objeto del tipo Numero</param>
        /// <returns>El valor de la suma entre ambos numeros </returns>
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.GetNumero() + num2.GetNumero();
        }
        #endregion
    }
}
