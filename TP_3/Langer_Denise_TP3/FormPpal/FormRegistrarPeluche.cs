using Entidades;
using Entidades.Clases;
using Entidades.Exceptions;
using System;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormRegistrarPeluche : Form
    {
        Fabrica fabrica;
        Peluche pelucheForm;
        FileManager fileManger;

        /// <summary>
        /// Constructor sin parametros que instancia el fileManager.
        /// </summary>
        public FormRegistrarPeluche()
        {
            InitializeComponent();
            fileManger = new FileManager();
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        public FormRegistrarPeluche(string razonSocial) : this()
        {
            fabrica = Fabrica.GetFabrica(razonSocial);
        }

        /// <summary>
        /// Constructor que recibe la razonSocial de la Fabrica y un peluche ya instanciado para su modificacion
        /// </summary>
        /// <param name="razonSocial">Razon social de la Fabrica</param>
        /// <param name="peluche">peluche que se quiere actualizar los campos</param>
        public FormRegistrarPeluche(string razonSocial, Peluche peluche) : this(razonSocial)
        {
            this.pelucheForm = peluche;
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
        /// Propiedad de Lectura y Escritura para num_Tamaño
        /// </summary>
        public int TamañoCM
        {
            get { return (int)num_Tamaño.Value; }
            set { num_Tamaño.Value = value; }
        }

        /// <summary>
        /// Evento Load del Formulario. Settea los valores de los Combo Box y valida si el formulario se requiere al momento
        /// de registrar un peluche o editarlo (segun su Propiedad Text).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormRegistrarPeluche_Load(object sender, EventArgs e)
        {
            cmb_Material.DataSource = Enum.GetValues(typeof(EMateriales));
            cmb_Color.DataSource = Enum.GetValues(typeof(EColores));
            if (this.Text.Equals("Cambiar diseño del Peluche"))
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
        /// Crear un Peluche nuevo: se crea una instancia con los valores ingresados, validando que haya cantidad disponible de materiales 
        /// para la fabricacion y que no exista un Peluche ya registrado con la misma marca y diseño.
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
                if (num_CantProd.Value <= 0 || num_Tamaño.Value <= 0)
                    MessageBox.Show("Los campos Partes a Ensamblar, Cantidad a Producir y Tamaño deben contener un valor mayor a 0", "Valores invalidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (String.IsNullOrWhiteSpace(txt_Marca.Text) || String.IsNullOrWhiteSpace(txt_Modelo.Text))
                    MessageBox.Show("Debe ingresar la Marca y/o el Modelo del juguete", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (this.Text.Equals("Registrar Peluche"))
                    {
                        pelucheForm = new Peluche((EMateriales)cmb_Material.SelectedItem, (int)num_CantProd.Value, txt_Marca.Text, txt_Modelo.Text, (EColores)cmb_Color.SelectedIndex, (int)num_Tamaño.Value, Peluche.EMedida.Centimetros);
                        if (radio_Milim.Checked)
                            pelucheForm.Medida = Peluche.EMedida.Milimetros;
                        if (radio_Metro.Checked)
                            pelucheForm.Medida = Peluche.EMedida.Metros;

                        pelucheForm.TamañoCm = pelucheForm.CalcularCentimetros((int)num_Tamaño.Value, pelucheForm.Medida);

                        fabrica.ValidarProduccion(pelucheForm, pelucheForm.CantidadProduccion);
                        fabrica.AgregarList(pelucheForm);
                        MessageBox.Show($"Se ha registrado el Peluche con la siguiente informacion:\n{pelucheForm.MostrarDatos()}", "Exito", MessageBoxButtons.OK);
                        Limpiar();
                    }
                    else
                    {
                        if (CantidadProducir < pelucheForm.CantidadProduccion)
                        {
                            throw new Exception("La cantidad a producir debe ser mayor a la anterior");
                        }
                        if (fabrica.ValidarProduccion(pelucheForm, (CantidadProducir - pelucheForm.CantidadProduccion)))
                        {
                            int indexActual = fabrica.Juguetes.IndexOf(pelucheForm);
                            pelucheForm = fabrica.CambiarDiseñoPeluche(this.pelucheForm, (EMateriales)cmb_Material.SelectedItem, CantidadProducir, Marca, Modelo, (EColores)cmb_Color.SelectedIndex, TamañoCM, Peluche.EMedida.Centimetros);

                            if (radio_Milim.Checked)
                                pelucheForm.Medida = Peluche.EMedida.Milimetros;
                            if (radio_Metro.Checked)
                                pelucheForm.Medida = Peluche.EMedida.Metros;

                            pelucheForm.TamañoCm = pelucheForm.CalcularCentimetros(TamañoCM, pelucheForm.Medida);
                            fabrica.Juguetes.RemoveAt(indexActual);
                        }
                        MessageBox.Show($"Se han modificados los datos:\n{pelucheForm.MostrarDatos()}", "Modificacion exitosa", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
            catch (NoMaterialesException exMat)
            {
                fileManger.Guardar(exMat.ToString());
                MessageBox.Show(exMat.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JugueteYaExisteException exJug)
            {
                fileManger.Guardar(exJug.ToString());
                MessageBox.Show(exJug.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                fileManger.Guardar(ex.ToString());
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
    }
}
