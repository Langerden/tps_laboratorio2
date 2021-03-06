using Entidades;
using Entidades.Clases;
using FormPpal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formularios
{
    public delegate void PasarEntidad(Juguete juguete);

    public partial class FormCambiarDiseño : Form
    {
        private FileManager fileManager;
        private Serializer<Juguete> serializer;

        public FileManager FileManager { get => fileManager; set => fileManager = value; }

        /// <summary>
        /// Constructor sin parametros del Formulario
        /// </summary>
        public FormCambiarDiseño()
        {
            InitializeComponent();
            this.fileManager = new FileManager();
            this.serializer = new Serializer<Juguete>();
        }


        /// <summary>
        /// Evento Load del Formulario. Settea los valores del ComboBox y activa / desactiva botones, segun diferentes validaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCambiarDiseño_Load(object sender, EventArgs e)
        {
            cmb_Clases.DataSource = new List<string>() { "Peluche", "Muñeco", "Inflable" };
            this.ActivarBotones();
        }

        /// <summary>
        /// Evento del boton Seleccionar. Segun la opcion elegida del Combo Box, instancia y reutiliza 
        /// un formulario de registro, setteando / modificando sus valores.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarSeleccionDatagrid(dataGrid))
                {
                    Fabrica.TablaActual = cmb_Clases.Text;
                    if (cmb_Clases.Text.StartsWith("M"))
                    {
                        Muñeco m = (Muñeco)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarMuñeco registrarMuñeco = new FormRegistrarMuñeco(m);
                        registrarMuñeco.Text = "Cambiar diseño del Muñeco";
                        registrarMuñeco.ShowDialog();
                    }
                    else if (cmb_Clases.Text.StartsWith("I"))
                    {
                        Inflable i = (Inflable)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarInflable registrarInflable = new FormRegistrarInflable(i);
                        registrarInflable.Text = "Cambiar diseño del Inflable";
                        registrarInflable.ShowDialog();
                    }
                    else
                    {
                        Peluche p = (Peluche)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarPeluche registrarPeluche = new FormRegistrarPeluche(p);
                        registrarPeluche.Text = "Cambiar diseño del Peluche";
                        registrarPeluche.ShowDialog();
                    }
                }
                this.ActualizarDataGridSQL();
            }
            catch (NullReferenceException ex)
            {
                fileManager.Guardar(ex.ToString());
                MessageBox.Show("Debe elegir una opcion de la lista", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Evento que se dispara cuando se cambia el Combo Box seleccionado. 
        /// Cada vez que se dispara, hace un abort del hilo actual (agregado a la cola) e instancia otro hilo que irá actualizando los valores del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Clases_SelectedValueChanged(object sender, EventArgs e)
        {
            Fabrica.TablaActual = cmb_Clases.SelectedItem.ToString().ToLower();
            this.ActualizarDataGridSQL();
        }



        /// <summary>
        /// Evento FormClosing. Confirma la salida del usuario y aborta todos los hilos que pueden estar activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCambiarDiseño_FormClosing(object sender, FormClosingEventArgs e)
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

        /// <summary>
        /// Metodo que activa o desactiva los botones, segun si hay almenos un registro en las listas actuales de la Fabrica
        /// </summary>		
        internal void ActivarBotones()
        {
            if (Fabrica.HayRegistros())
            {
                this.btn_Eliminar.Enabled = true;
                this.btn_Seleccionar.Enabled = true;
            }
            else
            {
                this.btn_Eliminar.Enabled = false;
                this.btn_Seleccionar.Enabled = false;
            }
        }


        /// <summary>
        /// Metodo que se ejecutará en un hilo secundario. Cada 7 segundos actualiza los valores del DataGrid (segun el ComboBox seleccionado)
        /// </summary>
        internal void ActualizarDataGridSQL()
        {
            dataGrid.DataSource = null;

            if (Fabrica.TablaActual.Contains("muñeco"))
                dataGrid.DataSource = Fabrica.Muñecos;
            else if (Fabrica.TablaActual.Contains("inflable"))
                dataGrid.DataSource = Fabrica.Inflables;
            else
                dataGrid.DataSource = Fabrica.Peluches;

            this.ActivarBotones();
        }

        /// <summary>
        /// Metodo que se utiliza para validar que se seleccionó un campo del DataGrid
        /// </summary>
        /// <param name="miDataGrid"></param>
        /// <returns>True si se selecciona un campo del DataGrid o false en caso contrario</returns>
        private bool ValidarSeleccionDatagrid(DataGridView miDataGrid)
        {
            try
            {
                if (!(miDataGrid is null || miDataGrid.CurrentRow.DataBoundItem is null || (!(miDataGrid.CurrentRow.Selected))))
                    return true;
            }
            catch (NullReferenceException)
            { }
            return false;
        }

        /// <summary>
        /// Evento del Boton Historial. Instancia un FormSQL y lo muestra de forma modal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormSQL formSQL = new FormSQL(this);
            formSQL.ShowDialog();
        }

        /// <summary>
        /// Evento del Boton Eliminar. Elimina el elemento seleccionado del DataGrid en las tablas de registros actuales de la Base de Datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            bool result = false;

            try
            {
                if (ValidarSeleccionDatagrid(dataGrid))
                {
                    if (cmb_Clases.Text.StartsWith("I"))
                    {
                        Inflable auxInflable = (Inflable)dataGrid.CurrentRow.DataBoundItem;
                        result = SQLConector.Delete(auxInflable, auxInflable.MarcaProducto, auxInflable.Diseño.ToString());
                        Fabrica.TablaActual = auxInflable.GetType().Name;
                    }
                    else if (cmb_Clases.Text.StartsWith("M"))
                    {
                        Muñeco auxMuñeco = (Muñeco)dataGrid.CurrentRow.DataBoundItem;
                        result = SQLConector.Delete(auxMuñeco, auxMuñeco.MarcaProducto, auxMuñeco.Modelo);
                        Fabrica.TablaActual = auxMuñeco.GetType().Name;
                    }
                    else
                    {
                        Peluche auxPeluche = (Peluche)dataGrid.CurrentRow.DataBoundItem;
                        result = SQLConector.Delete(auxPeluche, auxPeluche.MarcaProducto, auxPeluche.Modelo);
                        Fabrica.TablaActual = auxPeluche.GetType().Name;
                    }

                    if (result)
                    {
                        MessageBox.Show("Se eliminó el Juguete con Exito!", "Eliminacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActualizarDataGridSQL();
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                fileManager.Guardar(ex.ToString());
            }
        }
    }
}

