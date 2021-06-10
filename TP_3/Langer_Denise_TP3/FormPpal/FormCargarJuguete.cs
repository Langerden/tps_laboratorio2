using Entidades;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormCargarJuguete : Form
    {
        Fabrica fabrica;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FormCargarJuguete()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormCargarJuguete(string razonSocial) : this()
        {
            fabrica = Fabrica.GetFabrica(razonSocial);
        }

        /// <summary>
        /// Evento del boton Muñeco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Muñeco_Click(object sender, EventArgs e)
        {
            FormRegistrarMuñeco registrarMuñeco = new FormRegistrarMuñeco(fabrica.RazonSocial);
            registrarMuñeco.ShowDialog();
        }

        /// <summary>
        /// Evento del boton Peluche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Peluche_Click(object sender, EventArgs e)
        {
            FormRegistrarPeluche registrarPeluche = new FormRegistrarPeluche(fabrica.RazonSocial);
            registrarPeluche.ShowDialog();
        }

        /// <summary>
        /// Evento del boton Inflable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Inflable_Click(object sender, EventArgs e)
        {
            FormRegistrarInflable registrarInflable = new FormRegistrarInflable(fabrica.RazonSocial);
            registrarInflable.ShowDialog();
        }

        /// <summary>
        /// Evento FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCargarJuguete_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Evento del boton Cancelar (reutiliza la logica del FormClosing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
