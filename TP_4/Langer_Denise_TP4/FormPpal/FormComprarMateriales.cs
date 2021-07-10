using Entidades;
using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormMateriales : Form
    {
        FileManager fileManager;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FormMateriales()
        {
            InitializeComponent();
            this.fileManager = new FileManager();
        }

        /// <summary>
        /// Evento Load del Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMateriales_Load(object sender, EventArgs e)
        {
            CargarElementos();
        }

        /// <summary>
        /// Evento del boton Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento del boton Comprar. Agrega la cantidad de Materia Prima ingresada por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Comprar_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaPrima.ComprarMateriales(EMateriales.Hilo, (int)num_Hilo.Value);
                MateriaPrima.ComprarMateriales(EMateriales.Plastico, (int)num_Plastico.Value);
                MateriaPrima.ComprarMateriales(EMateriales.Tela, (int)num_Tela.Value);
                CargarElementos();
                LimpiarElementos();
                MessageBox.Show("Los materiales fueron comprados con exito", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento Closing del Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMateriales_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;

        }
        /// <summary>
        /// Metodo que actualiza los valores de la Cantidad de Materia Prima disponible para cada tipo de Material.
        /// </summary>
        private void CargarElementos()
        {
            try
            {
                txt_Plastico.Text = MateriaPrima.CantidadPlastico.ToString();
                txt_Hilo.Text = MateriaPrima.CantidadHilo.ToString();
                txt_Tela.Text = MateriaPrima.CantidadTela.ToString();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Settea los valores por default de los NumericUpDown
        /// </summary>
        private void LimpiarElementos()
        {
            this.num_Hilo.Value = 0;
            this.num_Plastico.Value = 0;
            this.num_Tela.Value = 0;
        }
    }
}
