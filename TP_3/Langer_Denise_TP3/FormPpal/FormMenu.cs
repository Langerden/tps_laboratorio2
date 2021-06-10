using Entidades;
using Entidades.Clases;
using FormPpal;
using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Formularios
{
    public partial class PpalForm : Form
    {
        Fabrica fabrica;
        FileManager fileManager;
        SoundPlayer player;

        /// <summary>
        /// Constructor sin parametros. Inicializa los atributos
        /// </summary>
        public PpalForm()
        {
            InitializeComponent();
            fabrica = new Fabrica("Toy Story");
            fileManager = new FileManager();
            player = new SoundPlayer();
        }

        /// <summary>
        /// Evento del Boton Materia Prima que instancia y muestra el formulario FormMateriales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MateriaPrima_Click(object sender, EventArgs e)
        {
            FormMateriales formMateriales = new FormMateriales();
            formMateriales.ShowDialog();
        }

        /// <summary>
        /// Evento del Boton CambiarDiseño que instancia y muestra el formulario FormCambiarDiseño
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CambiarDiseño_Click(object sender, EventArgs e)
        {
            fabrica = Fabrica.GetFabrica(fabrica.RazonSocial);
            FormCambiarDiseño formCambiarDiseño = new FormCambiarDiseño(fabrica.RazonSocial);
            formCambiarDiseño.ShowDialog();
        }

        /// <summary>
        /// Evento del Boton ElegirProducto que instancia y muestra el formulario FormCargarJuguete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ElegirProducto_Click(object sender, EventArgs e)
        {
            FormCargarJuguete formCargarJuguete = new FormCargarJuguete(fabrica.RazonSocial);
            formCargarJuguete.ShowDialog();
        }

        /// <summary>
        /// Evento del Boton Salir. En caso de ejecutar alguna Exception, indica que se pudo generar el archivo de texto en un path especifico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento Load del Formulario para especificar la ruta del Audio.
        /// En caso de errores, arroja una Excepcion con un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PpalForm_Load(object sender, EventArgs e)
        {
            string audio = "ToyStory.wav";
            try
            {
                player.SoundLocation = $"{Environment.CurrentDirectory}/{audio}";
                player.PlayLooping();
            }
            catch (FileNotFoundException exFile)
            {
                fileManager.Guardar(exFile.ToString());
                MessageBox.Show($"Hubo un problema al reproducir el sonido del formulario {audio}", "Audio No encontrado");
            }
        }

        /// <summary>
        /// Evento del boton Fabricar que instancia y muestra el formulario FormFabricar en caso haber registrado previamente al menos un Juguete
        /// En caso contrario, muestra un MessageBox con un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Fabricar_Click(object sender, EventArgs e)
        {
            fabrica = Fabrica.GetFabrica(fabrica.RazonSocial);

            if (fabrica.Juguetes.Count > 0)
            {
                FormFabricar formFabricar = new FormFabricar(fabrica.RazonSocial);
                formFabricar.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tiene que haber almenos un juguete registrado", "Registrate Algo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PpalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que quiere terminar con la ejecucion del programa?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    player.SoundLocation = $"{Environment.CurrentDirectory}/BuzzInfinito.wav";
                    player.Play();
                    string datos = string.Empty;
                    if (fileManager.Leer(out datos))
                        MessageBox.Show($"Se creo un archivo de texto con las excepciones lanzadas en la ruta {fileManager.Ruta}", "Excepciones capturadas", MessageBoxButtons.OK);
                    else
                        MessageBox.Show($"No se pudo crear ningun archivo de texto porque no hubo errores durante la ejecucion ;)", "Excepciones no capturadas", MessageBoxButtons.OK);
                }
                catch (FileNotFoundException exFile)
                {
                    MessageBox.Show(exFile.Message, "Hubo un error al crear el archivo de texto", MessageBoxButtons.OK);
                }
            }
        }
    }
}
