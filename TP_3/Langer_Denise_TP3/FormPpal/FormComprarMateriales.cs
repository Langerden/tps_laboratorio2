using Entidades;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormMateriales : Form
    {

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FormMateriales()
        {
            InitializeComponent();
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
            MateriaPrima.CantidadHilo += (int)num_Hilo.Value;
            MateriaPrima.CantidadPlastico += (int)num_Plastico.Value;
            MateriaPrima.CantidadTela += (int)num_Tela.Value;
            MessageBox.Show("Los materiales fueron comprados con exito", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarElementos();
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
            txt_Plastico.Text = MateriaPrima.CantidadPlastico.ToString();
            txt_Hilo.Text = MateriaPrima.CantidadHilo.ToString();
            txt_Tela.Text = MateriaPrima.CantidadTela.ToString();
        }
    }
}
