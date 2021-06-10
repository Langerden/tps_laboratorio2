using Entidades;
using Entidades.Clases;
using Entidades.Exceptions;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarInflable : Form
    {
        Fabrica fabrica;
        Inflable inflableForm;
        FileManager fileManager;

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager.
        /// </summary>
        public FormRegistrarInflable()
        {
            InitializeComponent();
            fileManager = new FileManager();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormRegistrarInflable(string razonSocial) : this()
        {
            fabrica = Fabrica.GetFabrica(razonSocial);
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica y un inflable ya instanciado para su modificacion
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        /// <param name="inflable">Inflable que se quiere actualizar los campos</param>
        public FormRegistrarInflable(string razonSocial, Inflable inflable) : this(razonSocial)
        {
            this.inflableForm = inflable;
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para num_CantProd
        /// </summary>
        public int CantidadProducir
        {
            get { return (int)num_CantProd.Value; }
            set { num_CantProd.Value = value; }
        }


        /// <summary>
        /// Propiedad de Lectura y Escritura para txt_Marca
        /// </summary>
        public string Marca
        {
            get { return txt_Marca.Text; }
            set { txt_Marca.Text = value; }
        }

        /// <summary>
        /// Evento Load del Formulario. Settea los valores de los Combo Box y valida si el formulario se requiere al momento
        /// de registrar un Inflable o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarInflable_Load(object sender, EventArgs e)
        {
            cmb_Material.DataSource = Enum.GetValues(typeof(EMateriales));
            cmb_Color.DataSource = Enum.GetValues(typeof(EColores));
            cmb_Diseño.DataSource = Enum.GetValues(typeof(Inflable.EDiseño));
            if (this.Text.Equals("Cambiar diseño del Inflable"))
                txt_Marca.Enabled = false;
        }

        /// <summary>
        /// Evento del boton Cancelar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                this.Close();
        }

        /// <summary>
        /// Evento del boton Guardar. Valida que los campos esten correctamente cargados.
        /// Crear un Inflable nuevo: se crea una instancia con los valores ingresados, validando que haya cantidad disponible de materiales 
        /// para la fabricacion y que no exista un Inflable ya registrado con la misma marca y diseño.
        /// Editar sus valores: valida que la cantidad de producir actual no sea menor a la anterior y en caso de editarlo, resta la diferencia de
        /// materiales a utilizar, actualizando todos los campos requeridos.
        /// En caso de fallas, arroja la excepcion correspondiente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (num_CantProd.Value <= 0)
                    MessageBox.Show("Debe ingresar una Cantidad a Producir mayor a 0", "Cantidad no Valida", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                else if (String.IsNullOrWhiteSpace(txt_Marca.Text))
                    MessageBox.Show("Debe ingresar la marca del juguete", "Marca vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (this.Text.Equals("Registrar Inflable"))
                    {
                        inflableForm = new Inflable((EMateriales)cmb_Material.SelectedItem, (int)num_CantProd.Value, txt_Marca.Text, (Inflable.EDiseño)cmb_Diseño.SelectedIndex, (EColores)cmb_Color.SelectedIndex);
                        fabrica.ValidarProduccion(inflableForm, inflableForm.CantidadProduccion);
                        fabrica.AgregarList(inflableForm);
                        MessageBox.Show($"Se ha registrado el Inflable con la siguiente informacion:\n{inflableForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < inflableForm.CantidadProduccion)
                        {
                            throw new Exception("La cantidad a producir debe ser mayor o igual a la anterior");
                        }
                        if (fabrica.ValidarProduccion(inflableForm, (CantidadProducir - inflableForm.CantidadProduccion)))
                        {
                            int indexActual = fabrica.Juguetes.IndexOf(inflableForm);
                            inflableForm = fabrica.CambiarDiseñoInflable(this.inflableForm, (EMateriales)cmb_Material.SelectedItem, CantidadProducir, Marca, (Inflable.EDiseño)cmb_Diseño.SelectedIndex, (EColores)cmb_Color.SelectedIndex);
                            fabrica.Juguetes.RemoveAt(indexActual);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{inflableForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (NoMaterialesException exMat)
            {
                fileManager.Guardar(exMat.ToString());
                MessageBox.Show(exMat.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JugueteYaExisteException exJug)
            {
                fileManager.Guardar(exJug.ToString());
                MessageBox.Show(exJug.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para actualizar los valores por default
        /// </summary>
        private void Limpiar()
        {
            num_CantProd.Value = 0;
            txt_Marca.Text = string.Empty;
        }
    }
}
