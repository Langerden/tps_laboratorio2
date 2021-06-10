using Entidades;
using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormPpal
{
    public partial class FormFabricar : Form
    {
        private Fabrica fabrica;
        private Serializer<Juguete> serializer;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FormFabricar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica e instancia el Serializer
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormFabricar(string razonSocial) : this()
        {
            fabrica = Fabrica.GetFabrica(razonSocial);
            this.serializer = new Serializer<Juguete>();
        }

        /// <summary>
        /// Evento Load del Formulario. Carga el ProgressBar y activa el boton Aceptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFabricar_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < bar_Fabricar.Maximum; i++)
            {
                bar_Fabricar.Value++;
            }

            if (bar_Fabricar.Value == bar_Fabricar.Maximum)
                btn_Aceptar.Enabled = true;
        }

        /// <summary>
        /// Serializa los Juguetes fabricados a un archivo.xml y limpia la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Peluche> peluches = new List<Peluche>();
                List<Inflable> inflables = new List<Inflable>();
                List<Muñeco> muñecos = new List<Muñeco>();
                foreach (Juguete item in fabrica.Juguetes)
                {
                    switch (item.GetType().Name)
                    {
                        case "Peluche":
                            peluches.Add((Peluche)item);
                            break;
                        case "Inflable":
                            inflables.Add((Inflable)item);
                            break;
                        case "Muñeco":
                            muñecos.Add((Muñeco)item);
                            break;
                    }
                }
                if (peluches.Count > 0)
                    serializer.Guardar<Peluche>(peluches);
                if (inflables.Count > 0)
                    serializer.Guardar<Inflable>(inflables);
                if (muñecos.Count > 0)
                    serializer.Guardar<Muñeco>(muñecos);

                MessageBox.Show("Se han fabricado los juguetes con exito!", "Fabricacion completa", MessageBoxButtons.OK);
                fabrica.Juguetes.Clear();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Serializar", MessageBoxButtons.OK);
            }
        }
    }
}
