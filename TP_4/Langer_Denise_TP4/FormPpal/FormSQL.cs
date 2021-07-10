using Entidades;
using Entidades.Clases;
using Formularios;
using System;
using System.Windows.Forms;

namespace FormPpal
{
    public partial class FormSQL : Form
    {
        FormCambiarDiseño formDiseño;

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public FormSQL()
        {
            InitializeComponent();
        }

        public FormSQL(FormCambiarDiseño formDiseño) : this()
        {
            this.formDiseño = formDiseño;
        }

        /// <summary>
        /// Evento Load del Formulario. Llama al Metodo ActualizarCampos()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSQL_Load(object sender, EventArgs e)
        {
            ActualizarCampos();
        }

        /// <summary>
        /// Carga cada DataGrid con los valores de la tabla del historial (correspondiente a cada entidad) desde la Base de Datos
        /// </summary>
        private void ActualizarCampos()
        {
            this.dataPeluche.DataSource = SQLConector.LeerPeluche("historial_peluche");
            this.dataMuñeco.DataSource = SQLConector.LeerMuñeco("historial_muñeco");
            this.dataInflable.DataSource = SQLConector.LeerInflable("historial_inflable");
        }

        /// <summary>
        /// Muestra en un label la cantidad de registros totales de cada tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblContar.Text = $"Inflables: {SQLConector.ContarRegistros("historial_inflable")}, Peluches: {SQLConector.ContarRegistros("historial_peluche")}, Muñeco: {SQLConector.ContarRegistros("historial_muñeco")}";
            }
            catch (Exception ex)
            {
                formDiseño.FileManager.Guardar(ex.ToString());
            }
        }

        /// <summary>
        /// Cierra el Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que se dispara al hacer doble click sobre un registro del DataGrid de Peluches.
        /// Le permite al usuario volver a fabricar un Peluche que ya fue registrado en el historial,
        /// insertandolo en las tablas/listas actuales.
        /// Valida previamente que no se dupliquen los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataPeluche_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea volver a fabrica este juguete?", "Volver a Fabricar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Peluche aux = (Peluche)dataPeluche.CurrentRow.DataBoundItem;
                if (Fabrica.ValidarRegistrosPeluches(aux, Fabrica.Peluches))
                {
                    MessageBox.Show("No se pudo insertar el Peluche porque ya se encuentra registrado en la lista actual", "Peluche ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SQLConector.InsertActual((Peluche)dataPeluche.CurrentRow.DataBoundItem);
                    MessageBox.Show("Se insertó el Peluche a la lista de fabricacion actual!", "Peluche insertado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    formDiseño.ActualizarDataGridSQL();
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer doble click sobre un registro del DataGrid de Muñecos.
        /// Le permite al usuario volver a fabricar un Muñeco que ya fue registrado en el historial,
        /// insertandolo en las tablas/listas actuales.
        /// Valida previamente que no se dupliquen los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataMuñeco_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea volver a fabrica este juguete?", "Volver a Fabricar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Muñeco aux = (Muñeco)dataMuñeco.CurrentRow.DataBoundItem;
                if (Fabrica.ValidarRegistrosMuñecos(aux, Fabrica.Muñecos))
                {
                    MessageBox.Show("No se pudo insertar el Muñeco porque ya se encuentra registrado en la lista actual", "Muñeco ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SQLConector.InsertActual((Muñeco)dataMuñeco.CurrentRow.DataBoundItem);
                    MessageBox.Show("Se insertó el Muñeco a la lista de fabricacion actual!", "Muñeco insertado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    formDiseño.ActualizarDataGridSQL();
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer doble click sobre un registro del DataGrid de Inflable.
        /// Le permite al usuario volver a fabricar un Inflable que ya fue registrado en el historial,
        /// insertandolo en las tablas/listas actuales.
        /// Valida previamente que no se dupliquen los registros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataInflable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea volver a fabrica este juguete?", "Volver a Fabricar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Inflable aux = (Inflable)dataInflable.CurrentRow.DataBoundItem;
                if (Fabrica.ValidarRegistrosInflables(aux, Fabrica.Inflables))
                {
                    MessageBox.Show("No se pudo insertar el Inflable porque ya se encuentra registrado en la lista actual", "Inflable ya registrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SQLConector.InsertActual((Inflable)dataInflable.CurrentRow.DataBoundItem);
                    MessageBox.Show("Se insertó el Inflable a la lista de fabricacion actual!", "Inflable insertado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    formDiseño.ActualizarDataGridSQL();
                }
            }
        }
    }
}
