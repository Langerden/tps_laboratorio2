using Entidades;
using Entidades.Clases;
using Entidades.Exceptions;
using FormPpal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Formularios
{

    public partial class PpalForm : Form
    {
        FileManager fileManager;
        SoundPlayer player;
        List<Thread> listaThreads;

        /// <summary>
        /// Constructor sin parametros. Inicializa los atributos e instancia los hilos de la lista que ejecutarán durante el programa.
        /// </summary>
        public PpalForm()
        {
            InitializeComponent();
            fileManager = new FileManager();
            player = new SoundPlayer();
            this.listaThreads = new List<Thread>() { new Thread(Fabrica.ActualizarListas), new Thread(Binary.SerializarMateriales) };
            Fabrica.RazonSocial = "Toy Story";
        }

        /// <summary>
        /// Propiedad que retorna la instancia del FileManager
        /// </summary>
        public FileManager MiFileManager
        {
            get { return this.fileManager; }
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
            FormCambiarDiseño formCambiarDiseño = new FormCambiarDiseño();
            formCambiarDiseño.ShowDialog();
        }

        /// <summary>
        /// Evento del Boton ElegirProducto que instancia y muestra el formulario FormCargarJuguete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ElegirProducto_Click(object sender, EventArgs e)
        {
            FormCargarJuguete formCargarJuguete = new FormCargarJuguete();
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
        /// Hace el .Start() del hilo
        /// En caso de errores, arroja una Excepcion con un mensaje
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PpalForm_Load(object sender, EventArgs e)
        {
            this.listaThreads.ForEach(hilo => hilo.Start());
            Reproductor("ToyStory");
        }

        /// <summary>
        /// Metodo manejador del evento MostrarExcepciones de la Fabrica. 
        /// Mostrará los MessageBox de errores con el mensaje y titulo ingresado como parametro
        /// </summary>
        /// <param name="msgError"></param>
        /// <param name="title"></param>
        public void LanzarErrores(string msgError, string title)
        {
            MessageBox.Show(msgError + $"\nLa excepcion fue guardada en la siguiente ruta: \n\n{this.fileManager.Ruta}",
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        /// <summary>
        /// Metodo que ejecutara la cancion repetitivamente (validando que exista) durante la ejeucion del programa. 
        /// En caso conrario mostrará un mensaje de error.
        /// </summary>
        /// <param name="audio"></param>
        private void Reproductor(string audio)
        {
            try
            {
                player.SoundLocation = $"{Environment.CurrentDirectory}\\Music\\{audio}.wav";
                player.PlayLooping();
            }
            catch (FileNotFoundException exFile)
            {
                fileManager.Guardar(exFile.ToString());
                this.LanzarErrores($"Hubo un problema al reproducir el sonido del formulario {audio}", "Audio No encontrado");
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
            try
            {
                if (Fabrica.HayRegistros())
                {
                    FormFabricar formFabricar = new FormFabricar();
                    formFabricar.ShowDialog();
                }
                else
                {
                    throw new NoHayJuguetesRegistradosException("Tiene que haber almenos un juguete registrado");
                }
            }
            catch (NoHayJuguetesRegistradosException ex)
            {
                this.fileManager.Guardar(ex.ToString());
                this.LanzarErrores(ex.Message, "Registrate Algo");
            }
        }

        /// <summary>
        /// Evento FormClosing. Confirma si se quiere salir del programa.
        /// En caso de aceptar, cierra la coneccion con la Base de Datos y aborta el hilo que actualiza las listas de la Fabrica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    Reproductor("BuzzInfinito");
                }
                catch (FileNotFoundException exFile)
                {
                    this.fileManager.Guardar(exFile.ToString());
                }
                finally
                {
                    SQLConector.CerrarConexion();

                    this.listaThreads.ForEach(hilo => { if (hilo.IsAlive) hilo.Abort(); });
                }
            }
        }
    }
}
