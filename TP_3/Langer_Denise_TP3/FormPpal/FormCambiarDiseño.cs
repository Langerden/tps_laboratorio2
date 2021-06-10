using Entidades;
using Entidades.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormCambiarDiseño : Form
    {
        Fabrica fabrica;
        FileManager fileManager;
        Serializer<Juguete> serializer;
        List<Juguete> historial;
        private bool historialActivo;

        /// <summary>
        /// Constructor sin parametros del Formulario
        /// </summary>
        public FormCambiarDiseño()
        {
            InitializeComponent();
            this.fileManager = new FileManager();
            this.serializer = new Serializer<Juguete>();
            this.historial = new List<Juguete>();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormCambiarDiseño(string razonSocial) : this()
        {
            this.fabrica = Fabrica.GetFabrica(razonSocial);
            historialActivo = false;
        }

        /// <summary>
        /// Evento Load del Formulario. Settea los valores del ComboBox y activa / desactiva botones, segun diferentes validaciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCambiarDiseño_Load(object sender, EventArgs e)
        {
            cmb_Clases.DataSource = new List<string>() { "Peluche", "Muñeco", "Inflable" };
            MostrarHistorial();

            if (fabrica.Juguetes.Count > 0 && btn_DatosActuales.Enabled == false)
                btn_Seleccionar.Enabled = true;

            if (historial.Count > 0)
                btn_Historial.Enabled = true;
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
                    if (cmb_Clases.Text.StartsWith("M"))
                    {
                        Muñeco m = (Muñeco)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarMuñeco registrarMuñeco = new FormRegistrarMuñeco(fabrica.RazonSocial, m);
                        registrarMuñeco.Text = "Cambiar diseño del Muñeco";
                        registrarMuñeco.CantidadProducir = m.CantidadProduccion;
                        registrarMuñeco.Marca = m.MarcaProducto;
                        registrarMuñeco.Partes = m.CantidadPartes;
                        registrarMuñeco.Articulado = m.EsArticulado;
                        registrarMuñeco.LlevaRopa = m.LlevaRopa;
                        registrarMuñeco.ShowDialog();
                        ActualizarDataGrid("Muñeco", fabrica.Juguetes);
                    }
                    else if (cmb_Clases.Text.StartsWith("I"))
                    {
                        Inflable i = (Inflable)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarInflable registrarInflable = new FormRegistrarInflable(fabrica.RazonSocial, i);
                        registrarInflable.Text = "Cambiar diseño del Inflable";
                        registrarInflable.CantidadProducir = i.CantidadProduccion;
                        registrarInflable.Marca = i.MarcaProducto;
                        registrarInflable.ShowDialog();
                        ActualizarDataGrid("Inflable", fabrica.Juguetes);
                    }
                    else
                    {
                        Peluche p = (Peluche)dataGrid.CurrentRow.DataBoundItem;
                        FormRegistrarPeluche registrarPeluche = new FormRegistrarPeluche(fabrica.RazonSocial, p);
                        registrarPeluche.Text = "Cambiar diseño del Peluche";
                        registrarPeluche.CantidadProducir = p.CantidadProduccion;
                        registrarPeluche.Marca = p.MarcaProducto;
                        registrarPeluche.Modelo = p.Modelo;
                        registrarPeluche.TamañoCM = p.TamañoCm;
                        registrarPeluche.ShowDialog();
                        ActualizarDataGrid("Peluche", fabrica.Juguetes);
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                fileManager.Guardar(ex.ToString());
                MessageBox.Show("Debe elegir una opcion de la lista", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Evento del boton Historial.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Historial_Click(object sender, EventArgs e)
        {
            ActualizarDataGrid(cmb_Clases.SelectedItem.ToString(), historial);
            historialActivo = true;
            ActivarBotones(historialActivo);
        }

        /// <summary>
        /// Evento del boton Datos Actuales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_DatosActuales_Click(object sender, EventArgs e)
        {
            ActualizarDataGrid(cmb_Clases.SelectedItem.ToString(), fabrica.Juguetes);
            historialActivo = false;
            ActivarBotones(historialActivo);
        }

        /// <summary>
        /// Evento para actualizar el DataGrid segun el valor del Combo Box seleccionado y el boton que se encuentra activo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Clases_SelectedValueChanged(object sender, EventArgs e)
        {
            if (historialActivo)
                ActualizarDataGrid(cmb_Clases.SelectedItem.ToString(), historial);
            else
                ActualizarDataGrid(cmb_Clases.SelectedItem.ToString(), fabrica.Juguetes);
        }

        /// <summary>
        /// Evento FormClosing
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
        /// Metodo para Deserializar los archivos.xml a una lista del tipo correspondiente.
        /// </summary>
        private void MostrarHistorial()
        {
            List<Muñeco> listMuñeco = serializer.Leer<Muñeco>();
            if (listMuñeco.Count > 0)
                historial.AddRange(listMuñeco);

            List<Peluche> listPeluche = serializer.Leer<Peluche>();
            if (listPeluche.Count > 0)
                historial.AddRange(listPeluche);

            List<Inflable> listInflable = serializer.Leer<Inflable>();
            if (listInflable.Count > 0)
                historial.AddRange(listInflable);
        }

        /// <summary>
        /// Metodo que activa o desactiva los botones, segun el valor de historialActivo
        /// </summary>
        /// <param name="historialActivo">Variable booleana que indica si el boton Ultimos Fabricados se encuentra habilitado</param>
        private void ActivarBotones(bool historialActivo)
        {
            if (historialActivo)
            {
                btn_Seleccionar.Enabled = false;
                btn_DatosActuales.Enabled = true;
            }
            else
            {
                btn_DatosActuales.Enabled = false;
            }
        }

        /// <summary>
        /// Metodo que actualiza los elementos del DataGrid, segun el elemento seleccionado del Combo Box
        /// </summary>
        /// <param name="claseElegida">Valor del Combo Box seleccionado</param>
        /// <param name="listJuguete">Lista de Juguetes</param>
        private void ActualizarDataGrid(string claseElegida, List<Juguete> listJuguete)
        {
            dataGrid.DataSource = null;
            ArrayList juguetes = new ArrayList();

            foreach (Juguete item in listJuguete)
            {
                if (item.GetType().Name == claseElegida)
                {
                    juguetes.Add(item);
                }
            }
            dataGrid.DataSource = juguetes;
        }

        /// <summary>
        /// Metodo que se utiliza para validar que se seleccionó un campo del DataGrid
        /// </summary>
        /// <param name="miDataGrid"></param>
        /// <returns>True si se selecciona un campo del DataGrid o arroja una Excepcion en caso contrario</returns>
        private bool ValidarSeleccionDatagrid(DataGridView miDataGrid)
        {
            try
            {
                if (miDataGrid.CurrentRow.DataBoundItem is null)
                    return false;
                else
                    return true;
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
        }
    }
}

