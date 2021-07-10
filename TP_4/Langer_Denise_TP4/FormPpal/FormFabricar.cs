using Entidades;
using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace FormPpal
{
    public partial class FormFabricar : Form
    {
        private Serializer<Juguete> serializer;
        private FileManager fileManager;

        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public FormFabricar()
        {
            InitializeComponent();
            this.serializer = new Serializer<Juguete>();
            this.fileManager = new FileManager();
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
        /// Serializa los Juguetes fabricados a un archivo.xml.
        /// Recorre la lista de Juguetes actuales de la Fabrica:
        ///     Si el Juguete ya se estaba registrado previamente (segun la Primary Key) actualiza sus valores
        ///     Si el Juguete nunca fue registrado, lo inserta en la tabla de historial
        /// Por último, limpia las tablas de los registros actuales y las listas de la Fabrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Fabrica.Peluches.Count > 0)
                    serializer.Guardar<Peluche>(Fabrica.Peluches);
                if (Fabrica.Inflables.Count > 0)
                    serializer.Guardar<Inflable>(Fabrica.Inflables);
                if (Fabrica.Muñecos.Count > 0)
                    serializer.Guardar<Muñeco>(Fabrica.Muñecos);

                Fabrica.Muñecos.ForEach(item => SQLConector.InsertarHistorial(item));
                Fabrica.Inflables.ForEach(item => SQLConector.InsertarHistorial(item));
                Fabrica.Peluches.ForEach(item => SQLConector.InsertarHistorial(item));

                SQLConector.Limpiar();

                MessageBox.Show("Se han fabricado los juguetes con exito!", "Fabricacion completa", MessageBoxButtons.OK);
                this.Close();
            }
            catch (Exception ex)
            {
                this.fileManager.Guardar(ex.ToString());
                MessageBox.Show(ex.Message, "Ocurrió un error al querer Serializar las listas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
