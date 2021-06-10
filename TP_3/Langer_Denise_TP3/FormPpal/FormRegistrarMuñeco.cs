using Entidades;
using Entidades.Clases;
using Entidades.Exceptions;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarMuñeco : Form
    {
        Fabrica fabrica;
        Muñeco muñecoForm;
        FileManager fileManager;

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager.
        /// </summary>
        public FormRegistrarMuñeco()
        {
            InitializeComponent();
            this.fileManager = new FileManager();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormRegistrarMuñeco(string razonSocial) : this()
        {
            fabrica = Fabrica.GetFabrica(razonSocial);
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica y un muñeco ya instanciado para su modificacion
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        /// <param name="muñeco">Muñeco que se quiere actualizar los campos</param>
        public FormRegistrarMuñeco(string razonSocial, Muñeco muñeco) : this(razonSocial)
        {
            this.muñecoForm = muñeco;
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
                ;
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
                ;
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
        /// Evento Load del Formulario. Settea los valores del Combo Box y valida si el formulario se requiere al momento
        /// de registrar un Muñeco o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarMuñeco_Load(object sender, EventArgs e)
        {
            cmb_MateriaPrima.DataSource = Enum.GetValues(typeof(EMateriales));
            if (this.Text.Equals("Cambiar diseño del Muñeco"))
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
        /// Crear un Muñeco nuevo: se crea una instancia con los valores ingresados, validando que haya cantidad disponible de materiales 
        /// para la fabricacion y que no exista un Muñeco ya registrado con la misma marca.
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
                if (num_CantProd.Value <= 0 || num_PartesEnsamblar.Value <= 0)
                    MessageBox.Show("Los campos Partes a Ensamblar y Cantidad a Producir deben contener un valor mayor a 0", "Valores invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (String.IsNullOrWhiteSpace(txt_Marca.Text))
                    MessageBox.Show("Debe ingresar la Marca del juguete", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        muñecoForm = new Muñeco((EMateriales)cmb_MateriaPrima.SelectedItem, CantidadProducir, Marca, Partes, LlevaRopa, Articulado);
                        fabrica.ValidarProduccion(muñecoForm, muñecoForm.CantidadProduccion);
                        fabrica.AgregarList(muñecoForm);
                        MessageBox.Show($"Se ha registrado el Muñeco con la siguiente informacion:\n{muñecoForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < muñecoForm.CantidadProduccion)
                        {
                            throw new Exception("La cantidad a producir debe ser mayor a la anterior");
                        }

                        if (fabrica.ValidarProduccion(muñecoForm, (CantidadProducir - muñecoForm.CantidadProduccion)))
                        {
                            int indexActual = fabrica.Juguetes.IndexOf(muñecoForm);
                            muñecoForm = fabrica.CambiarDiseñoMuñeco(this.muñecoForm, (EMateriales)cmb_MateriaPrima.SelectedItem, CantidadProducir, Marca, Partes, LlevaRopa, Articulado);
                            fabrica.Juguetes.RemoveAt(indexActual);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{muñecoForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (NoMaterialesException exMat)
            {
                this.fileManager.Guardar(exMat.ToString());
                MessageBox.Show(exMat.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JugueteYaExisteException exJug)
            {
                this.fileManager.Guardar(exJug.ToString());
                MessageBox.Show(exJug.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.fileManager.Guardar(ex.ToString());
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
            num_PartesEnsamblar.Value = 0;
            radio_ArticSi.Checked = true;
            radio_IndumSi.Checked = true;
        }
    }
}
