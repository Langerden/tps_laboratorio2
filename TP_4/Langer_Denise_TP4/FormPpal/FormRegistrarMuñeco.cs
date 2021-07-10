using Entidades;
using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarMuñeco : Form
    {
        Muñeco muñecoForm;
        FileManager fileManager;
        PpalForm menu;

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager, settea los valores del ComboBox y asocia el metodo de LanzarErrores al evento de la Fabrica.
        /// </summary>
        public FormRegistrarMuñeco()
        {
            InitializeComponent();
            this.menu = new PpalForm();
            this.fileManager = this.menu.MiFileManager;

            cmb_MateriaPrima.DataSource = Enum.GetValues(typeof(EMateriales));
            Fabrica.MostrarExcepciones += menu.LanzarErrores;

        }

        /// <summary>
        /// Constructor que recibe un muñeco ya instanciado para su modificacion
        /// Instancia un delegado del tipo PasarEntidad, el cual invocara el metodo CambiarDiseño
        /// </summary>
        /// <param name="muñeco">Muñeco que se quiere actualizar los campos</param>
        public FormRegistrarMuñeco(Muñeco muñeco) : this()
        {
            PasarEntidad pasarEntidad = new PasarEntidad(CambiarDiseño);
            pasarEntidad.Invoke(muñeco);
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para el cmb_MateriaPrima
        /// </summary>
        public int Material
        {
            get { return cmb_MateriaPrima.SelectedIndex; }
            set { cmb_MateriaPrima.SelectedIndex = value; }
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
        /// Propiedad de Lectura y Escritura para txt_Modelo
        /// </summary>
        public string Modelo
        {
            get { return txt_Modelo.Text; }
            set { txt_Modelo.Text = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para num_PartesEnsamblar
        /// </summary>
        public int Partes
        {
            get { return (int)num_PartesEnsamblar.Value; }
            set { num_PartesEnsamblar.Value = value; }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para los radioButtons referentes a esArticulado 
        /// </summary>
        public bool Articulado
        {
            get
            {
                if (radio_ArticSi.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    radio_ArticSi.Checked = true;
                else
                    radio_ArticNo.Checked = true;
            }
        }

        /// <summary>
        /// Propiedad de Lectura y Escritura para los radioButtons referentes a llevaRopa 
        /// </summary>
        public bool LlevaRopa
        {
            get
            {
                if (radio_IndumSi.Checked)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    radio_IndumSi.Checked = true;
                else
                    radio_IndumNo.Checked = true;
            }
        }

        /// <summary>
        /// Evento Load del Formulario. Valida si el formulario se requiere al momento
        /// de registrar un Muñeco o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarMuñeco_Load(object sender, EventArgs e)
        {
            if (this.Text.Equals("Cambiar diseño del Muñeco"))
            {
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
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
        /// Crear un Muñeco nuevo: se crea una instancia con los valores ingresados, validando que haya cantidad disponible de materiales 
        /// para la fabricacion y que no exista un Muñeco ya registrado con la misma marca y modelo (Primary Key compuesta).
        /// Editar sus valores: permite al usuario actualizar/modificar los valores deseados. En caso de agregar una cantidad de producir menor a la anterior,
        /// el sistema calculará la diferencia de Materia Prima y lo agregara al stock.
        /// En caso de fallas, se catchea la excepcion, siendo vista por pantalla al invocar el metodo manejador previamente asociado al evento.        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (num_CantProd.Value <= 0 || num_PartesEnsamblar.Value <= 0)
                    MessageBox.Show("Los campos Partes a Ensamblar y Cantidad a Producir deben contener un valor mayor a 0", "Valores invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (String.IsNullOrWhiteSpace(txt_Marca.Text) || String.IsNullOrWhiteSpace(txt_Modelo.Text))
                    MessageBox.Show("Debe ingresar la Marca y/o el Modelo del juguete", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    bool radioButtonArt = false;
                    bool radioButtonIndum = false;

                    if (radio_ArticSi.Checked)
                        radioButtonArt = true;

                    if (radio_IndumSi.Checked)
                        radioButtonIndum = true;

                    if (this.Text.Equals("Registrar Muñeco"))
                    {
                        muñecoForm = new Muñeco((EMateriales)this.Material, this.CantidadProducir, this.Marca, this.Modelo, this.Partes, this.LlevaRopa, this.Articulado);
                        Fabrica.ValidarProduccion(muñecoForm, muñecoForm.CantidadProduccion);
                        Fabrica.AgregarList(muñecoForm);
                        MessageBox.Show($"Se ha registrado el Muñeco con la siguiente informacion:\n{muñecoForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < muñecoForm.CantidadProduccion)
                        {
                            muñecoForm.Material = (EMateriales)cmb_MateriaPrima.SelectedItem;
                            int cantSum = muñecoForm.CantidadProduccion - CantidadProducir;
                            cantSum = muñecoForm.CalcularMateriales(cantSum);
                            MateriaPrima.ComprarMateriales((EMateriales)cmb_MateriaPrima.SelectedItem, cantSum);
                        }

                        if (Fabrica.ValidarProduccion(muñecoForm, (CantidadProducir - muñecoForm.CantidadProduccion)))
                        {
                            muñecoForm = Fabrica.CambiarDiseñoMuñeco(this.muñecoForm, (EMateriales)this.Material, this.CantidadProducir, this.Marca, this.Modelo, this.Partes, this.LlevaRopa, this.Articulado);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{muñecoForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.fileManager.Guardar(ex.ToString());
            }
        }

        /// <summary>
        /// Metodo para actualizar los valores por default
        /// </summary>
        private void Limpiar()
        {
            num_CantProd.Value = 0;
            txt_Marca.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            num_PartesEnsamblar.Value = 0;
            radio_ArticSi.Checked = true;
            radio_IndumSi.Checked = true;
        }


        /// <summary>
        /// Metodo que se asignara al delegado PasarEntidad. 
        /// Inserta en cada elemento del formulario los valores correspondientes al Juguete ingresado como parametro
        /// </summary>
        /// <param name="juguete">Instancia del Juguete</param>
        private void CambiarDiseño(Juguete juguete)
        {
            this.muñecoForm = (Muñeco)juguete;
            this.Material = (int)Enum.Parse(typeof(EMateriales), muñecoForm.Material.ToString());
            this.CantidadProducir = muñecoForm.CantidadProduccion;
            this.Marca = muñecoForm.MarcaProducto;
            this.Modelo = muñecoForm.Modelo;
            this.Partes = muñecoForm.CantidadPartes;
            this.Articulado = muñecoForm.EsArticulado;
            this.LlevaRopa = muñecoForm.LlevaRopa;
        }

        /// <summary>
        /// Evento FormClosing. Desasocia el metodo manejador al evento de MostrarExcepciones de la Fabrica 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarMuñeco_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fabrica.MostrarExcepciones -= this.menu.LanzarErrores;
        }
    }
}
