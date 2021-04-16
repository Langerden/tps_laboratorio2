using System;
using System.Windows.Forms;
using System.Media;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Environment.CurrentDirectory + "/Pokemon.wav";
            player.PlayLooping();            
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Obtiene el valor numerico del calculo realizado en el método Operar
        /// de la clase Calculadora (en base a la operacion seleccionada y los numeros ingresados.)
        /// </summary>
        /// <param name="numero1">Primer numero para operar</param>
        /// <param name="numero2">Segundo numero para operar</param>
        /// <param name="operador">Operador seleccionado</param>
        /// <returns>Retorna el resultado numerico de la operacion seleccioanda entre ambos numeros</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.Operar(num1,num2,operador);
        }

        /// <summary>
        /// Implementacion del metodo Limpiar al tocar el boton Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Muestra un MessageBox para confirmar que desea cerrar la calculadora al tocar el boton Cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cerrar el formulario?", "Cerrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        /// <summary>
        /// Convierte el numero decimal a binario al tocar el boton en caso de ser posible y desactiva el boton.
        /// En caso de no contener ningun valor a convertir, arroja un MessageBox con un mensaje de error.
        /// Si el resultado es "Valor inválido", arroja un MessageBox indicando que debe realizar una operacion nueva o limpiar los valores actuales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text) || String.IsNullOrWhiteSpace(lblResultado.Text))
            {
                MessageBox.Show("Debe calcularse un resultado para realizar la conversion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Numero numeroDecimal = new Numero();
                lblResultado.Text = numeroDecimal.DecimalBinario(lblResultado.Text);

                if (String.Compare(lblResultado.Text, "Valor inválido") == 0)
                {
                    MessageBox.Show("Debe realizar otra operacion o limpiar los valores actuales", "Operacion no Valida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConvertirADecimal.Enabled = false;
                    btnConvertirABinario.Enabled = false;
                }
                else
                {
                    btnConvertirABinario.Enabled = false;
                    btnConvertirADecimal.Enabled = true;

                    if (btnConvertirADecimal.Enabled == false)
                        btnConvertirABinario.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Convierte el numero binario a decimal al tocar el boton en caso de ser posible y desactiva el boton.
        /// En caso de no contener ningun valor a convertir, arroja un MessageBox con un mensaje de error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text) || String.IsNullOrWhiteSpace(lblResultado.Text))
            {
                MessageBox.Show("Debe calcularse un resultado para realizar la conversion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Numero numeroBinario = new Numero();
                lblResultado.Text = numeroBinario.BinarioDecimal(lblResultado.Text);

                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;

                if (btnConvertirABinario.Enabled == false)
                    btnConvertirADecimal.Enabled = true;
            }
        }

        /// <summary>
        /// Realiza la operacion entre 2 numeros (previa validacion) segun el operador seleccionado del ComboBox
        /// En caso de no elegir un operador, o no ingresar 2 numeros en los TextBox, o ingresar letras en vez de numeros, arroja un MessageBox de error.
        /// En caso de querer dividir por 0, devuelve double.MinValue y se indica que no puede convertirse a binario, desactivando los botones de convertir a binario y a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text.Equals("") || String.IsNullOrEmpty(txtNumero1.Text) || String.IsNullOrEmpty(txtNumero2.Text))
            {
                    MessageBox.Show("Debe ingresar una operacion para continuar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!(Double.TryParse(txtNumero1.Text, out double num1ToDouble)) || (!(Double.TryParse(txtNumero2.Text, out double num2ToDouble))))
                {
                    MessageBox.Show("Debe ingresar numeros en vez de palabras o letras", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();

                    if (lblResultado.Text == (double.MinValue.ToString()))
                    {
                        MessageBox.Show("Error de operacion al querer dividir por cero. Resultado no puede convertirse a binario", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnConvertirABinario.Enabled = false;
                        btnConvertirADecimal.Enabled = false;
                    }
                    else
                    {
                        btnConvertirABinario.Enabled = true;
                        btnConvertirADecimal.Enabled = false;
                    }
                }
            }
        }        
    }
}
