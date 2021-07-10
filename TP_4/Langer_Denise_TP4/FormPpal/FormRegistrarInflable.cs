using Entidades;
using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarInflable : Form
    {
        Inflable inflableForm;
        FileManager fileManager;
        PpalForm menu;

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager, settea los valores de cada ComboBox 
        /// y asocia el metodo de LanzarErrores al evento de la Fabrica.
        /// </summary>
        public FormRegistrarInflable()
        {
            InitializeComponent();
            this.menu = new PpalForm();
            fileManager = this.menu.MiFileManager;

            cmb_Material.DataSource = Enum.GetValues(typeof(EMateriales));
            cmb_Color.DataSource = Enum.GetValues(typeof(EColores));
            cmb_Diseño.DataSource = Enum.GetValues(typeof(Inflable.EDiseño));

            Fabrica.MostrarExcepciones += menu.LanzarErrores;
        }

        /// <summary>
        /// Constructor que recibe un inflable ya instanciado para su modificacion
        /// Instancia un delegado del tipo PasarEntidad, el cual invocara el metodo CambiarDiseño
        /// </summary>
        /// <param name="inflable">Inflable que se quiere actualizar los campos</param>
        public FormRegistrarInflable(Inflable inflable) : this()
        {
            PasarEntidad pasarEntidad = new PasarEntidad(CambiarDiseño);
            pasarEntidad.Invoke(inflable);
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el cmb_Material
        /// </summary>
        public int Material
        {
            get { return cmb_Material.SelectedIndex; }
            set { cmb_Material.SelectedIndex = value; }
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
        /// Propiedad de Lectura y Escritura para el cmb_Diseño
        /// </summary>
        public int Diseño
        {
            get { return cmb_Diseño.SelectedIndex; }
            set { cmb_Diseño.SelectedIndex = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el cmb_Color
        /// </summary>
        public int Color
        {
            get { return cmb_Color.SelectedIndex; }
            set { cmb_Color.SelectedIndex = value; }
        }

        /// <summary>
        /// Evento Load del Formulario. Valida si el formulario se requiere al momento
        /// de registrar un Inflable o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarInflable_Load(object sender, EventArgs e)
        {
            if (this.Text.Equals("Cambiar diseño del Inflable"))
            {
                txt_Marca.Enabled = false;
                cmb_Diseño.Enabled = false;
            }
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
        /// para la fabricacion y que no exista un Inflable ya registrado con la misma marca y diseño (Primary Key compuesta).
        /// Editar sus valores: permite al usuario actualizar/modificar los valores deseados. En caso de agregar una cantidad de producir menor a la anterior,
        /// el sistema calculará la diferencia de Materia Prima y lo agregara al stock.
        /// En caso de fallas, se catchea la excepcion, siendo vista por pantalla al invocar el metodo manejador previamente asociado al evento.
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
                    MessageBox.Show("Debe ingresar la Marca del juguete", "Marca vacia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (this.Text.Equals("Registrar Inflable"))
                    {
                        inflableForm = new Inflable((EMateriales)this.Material, this.CantidadProducir, this.Marca, (Inflable.EDiseño)this.Diseño, (EColores)this.Color);
                        Fabrica.ValidarProduccion(inflableForm, inflableForm.CantidadProduccion);
                        Fabrica.AgregarList(inflableForm);
                        MessageBox.Show($"Se ha registrado el Inflable con la siguiente informacion:\n{inflableForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < inflableForm.CantidadProduccion)
                        {
                            inflableForm.Material = (EMateriales)this.Material;
                            int cantSum = inflableForm.CantidadProduccion - CantidadProducir;
                            cantSum = inflableForm.CalcularMateriales(cantSum);
                            MateriaPrima.ComprarMateriales((EMateriales)this.Material, cantSum);
                        }
                        if (Fabrica.ValidarProduccion(inflableForm, (CantidadProducir - inflableForm.CantidadProduccion)))
                        {
                            inflableForm = Fabrica.CambiarDiseñoInflable(this.inflableForm, (EMateriales)this.Material, this.CantidadProducir, this.Marca, (Inflable.EDiseño)this.Diseño, (EColores)this.Color);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{inflableForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                fileManager.Guardar(ex.ToString());
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

        /// <summary>
        /// Evento FormClosing. Desasocia el metodo manejador al evento de MostrarExcepciones de la Fabrica 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarInflable_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fabrica.MostrarExcepciones -= this.menu.LanzarErrores;
        }

        /// <summary>
        /// Metodo que se asignara al delegado PasarEntidad. 
        /// Inserta en cada elemento del formulario los valores correspondientes al Juguete ingresado como parametro
        /// </summary>
        /// <param name="juguete">Instancia del Juguete</param>
        private void CambiarDiseño(Juguete juguete)
        {
            this.inflableForm = (Inflable)juguete;
            this.Material = (int)Enum.Parse(typeof(EMateriales), inflableForm.Material.ToString());
            this.CantidadProducir = inflableForm.CantidadProduccion;
            this.Marca = inflableForm.MarcaProducto;
            this.Diseño = (int)Enum.Parse(typeof(Inflable.EDiseño), inflableForm.Diseño.ToString());
            this.Color = (int)Enum.Parse(typeof(EColores), inflableForm.Color.ToString());
        }
    }
}
