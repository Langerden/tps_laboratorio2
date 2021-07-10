using Entidades;
using Entidades.Clases;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarPeluche : Form
    {
        Peluche pelucheForm;
        FileManager fileManger;
        PpalForm menu;

        #region Constructores

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager, settea los valores de cada ComboBox
        /// y asocia el metodo de LanzarErrores al evento de la Fabrica.
        /// </summary>
        public FormRegistrarPeluche()
        {
            InitializeComponent();
            this.menu = new PpalForm();
            fileManger = this.menu.MiFileManager;

            cmb_Material.DataSource = Enum.GetValues(typeof(EMateriales));
            cmb_Color.DataSource = Enum.GetValues(typeof(EColores));
            Fabrica.MostrarExcepciones += menu.LanzarErrores;
        }

        /// <summary>
        /// Constructor que recibe un Peluche ya instanciado para su modificacion
        /// Instancia un delegado del tipo PasarEntidad, el cual invocara el metodo CambiarDiseño
        /// </summary>
        /// <param name="peluche">peluche que se quiere actualizar los campos</param>
        public FormRegistrarPeluche(Peluche peluche) : this()
        {
            PasarEntidad pasarEntidad = new PasarEntidad(CambiarDiseño);
            pasarEntidad.Invoke(peluche);
        }

        #endregion

        #region Propiedades

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
        /// Propiedad de Lectura y Escritura para txt_Modelo
        /// </summary>
        public string Modelo
        {
            get { return txt_Modelo.Text; }
            set { txt_Modelo.Text = value; }
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
        /// Propiedad de Lectura y Escritura para num_Tamaño
        /// </summary>
        public int TamañoCM
        {
            get { return (int)num_Tamaño.Value; }
            set { num_Tamaño.Value = value; }
        }

        #endregion

        #region EventosFormluario
        /// <summary>
        /// Evento Load del Formulario. Valida si el formulario se requiere al momento
        /// de registrar un peluche o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarPeluche_Load(object sender, EventArgs e)
        {
            if (this.Text.Equals("Cambiar diseño del Peluche"))
            {
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
            }
        }

        /// <summary>
        /// Evento FormClosing. Desasocia el metodo manejador al evento de MostrarExcepciones de la Fabrica 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarPeluche_FormClosing(object sender, FormClosingEventArgs e)
        {
            Fabrica.MostrarExcepciones -= this.menu.LanzarErrores;
        }
        #endregion

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
        /// Crear un Peluche nuevo: se crea una instancia con los valores ingresados, validando que haya cantidad disponible de materiales 
        /// para la fabricacion y que no exista un Peluche ya registrado con la misma marca y modelo (Primary Key compuesta).
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
                if (num_CantProd.Value <= 0 || num_Tamaño.Value <= 0)
                    MessageBox.Show("Los campos Cantidad a Producir y Tamaño deben contener un valor mayor a 0", "Valores invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (String.IsNullOrWhiteSpace(txt_Marca.Text) || String.IsNullOrWhiteSpace(txt_Modelo.Text))
                    MessageBox.Show("Debe ingresar la Marca y/o el Modelo del juguete", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (this.Text.Equals("Registrar Peluche"))
                    {
                        pelucheForm = new Peluche(false, (EMateriales)this.Material, this.CantidadProducir, this.Marca, this.Modelo, (EColores)this.Color, this.TamañoCM, Peluche.EMedida.Centimetros);

                        if (radio_Milim.Checked)
                            pelucheForm.Medida = Peluche.EMedida.Milimetros;
                        if (radio_Metro.Checked)
                            pelucheForm.Medida = Peluche.EMedida.Metros;

                        pelucheForm.TamañoCm = pelucheForm.CalcularCentimetros(this.TamañoCM, pelucheForm.Medida);

                        Fabrica.ValidarProduccion(pelucheForm, pelucheForm.CantidadProduccion);
                        Fabrica.AgregarList(pelucheForm);
                        MessageBox.Show($"Se ha registrado el Peluche con la siguiente informacion:\n{pelucheForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < pelucheForm.CantidadProduccion)
                        {
                            pelucheForm.Material = (EMateriales)cmb_Material.SelectedItem;
                            int cantSum = pelucheForm.CantidadProduccion - CantidadProducir;
                            cantSum = pelucheForm.CalcularMateriales(cantSum);
                            MateriaPrima.ComprarMateriales((EMateriales)cmb_Material.SelectedItem, cantSum);
                        }
                        if (Fabrica.ValidarProduccion(pelucheForm, (CantidadProducir - pelucheForm.CantidadProduccion)))
                        {
                            if (radio_Milim.Checked)
                                pelucheForm.Medida = Peluche.EMedida.Milimetros;
                            if (radio_Metro.Checked)
                                pelucheForm.Medida = Peluche.EMedida.Metros;

                            pelucheForm.TamañoCm = pelucheForm.CalcularCentimetros(this.TamañoCM, pelucheForm.Medida);

                            pelucheForm = Fabrica.CambiarDiseñoPeluche(this.pelucheForm, (EMateriales)this.Material, this.CantidadProducir, this.Marca, this.Modelo, (EColores)this.Color, this.TamañoCM, Peluche.EMedida.Centimetros);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{pelucheForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.fileManger.Guardar(ex.ToString());
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
            num_Tamaño.Value = num_Tamaño.Minimum;
            radio_Centimetro.Checked = true;
        }

        /// <summary>
        /// Settea un valor minimo por default al num_Tamaño en caso de encontraste activado el radio_Milim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_Milim_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Milim.Checked)
            {
                num_Tamaño.Minimum = 50;
            }
            else
            {
                num_Tamaño.Minimum = 0;
                num_Tamaño.Value = num_Tamaño.Minimum;
            }
        }

        /// <summary>
        /// Metodo que se asignara al delegado PasarEntidad. 
        /// Inserta en cada elemento del formulario los valores correspondientes al Juguete ingresado como parametro
        /// </summary>
        /// <param name="juguete">Instancia del Juguete</param>
        private void CambiarDiseño(Juguete juguete)
        {
            this.pelucheForm = (Peluche)juguete;
            this.Material = (int)Enum.Parse(typeof(EMateriales), pelucheForm.Material.ToString());
            this.CantidadProducir = pelucheForm.CantidadProduccion;
            this.Marca = pelucheForm.MarcaProducto;
            this.Modelo = pelucheForm.Modelo;
            this.Color = (int)Enum.Parse(typeof(EColores), pelucheForm.Color.ToString());
            this.TamañoCM = pelucheForm.TamañoCm;
        }
    }
}
