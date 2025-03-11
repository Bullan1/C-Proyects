using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//Traemos las carpetas para hacer referencia a los archivos
using CarteleraCine.Controller;
using CarteleraCine.Model;

namespace CarteleraCine.View
{
    public partial class FormularioCRUD : Form
    {
        //Instancia de ApplicationDbContext para la conexión a la base de datos
        public ApplicationDbContext dbContext;
        //Instancia de PeliculaController para controlar las operaciones CRUD de película
        public PeliculaController controlador;

        public FormularioCRUD()
        {
            InitializeComponent();
            //Inicializamos el contexto de la base de datos
            dbContext = new ApplicationDbContext();
            //Inicializamos el controlador para traer las operaciones
            controlador = new PeliculaController();
            //Invocamos el Metodo Mostrar  
            MostrarPeliculas();
        }

        //Boton de Evento Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
      
            //Crear una nueva película con los datos del formulario instanciando la clase
            Pelicula nuevaPelicula = new Pelicula
            {
                //Enlazamos los atributos de la clase con los campos del formulario
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Categoria = comboBoxCategoria.Text,
                Precio = int.Parse(txtPrecio.Text)
            };
            //Llamamos al método AgregarPelicula del controlador
            controlador.AgregarPelicula(nuevaPelicula);
            //Actualizamos la tabla
            MostrarPeliculas();
            // Mostrar mensaje de éxito
            MessageBox.Show("Película agregada correctamente.");
        }
        //Metodo Mostrar
        public void MostrarPeliculas()
        {
            //Traemos los datos de la tabla Pelicula
            var pelicula = dbContext.Pelicula.ToList();
            //Mostramos los datos en el GridView
            dataGridView1.DataSource = pelicula;
        }
 

        //Boton Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Verificamos si se ha seleccionado una fila en el dataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Obtiene la película seleccionada de la fila seleccionada
                var pelicula = dataGridView1.SelectedRows[0].DataBoundItem as Pelicula;
                //Verifica si se pudo obtener una película válida
                if (pelicula != null)
                {
                    //Actualizamos los datos de la película con los valores ingresados en los controles del formulario
                    pelicula.Nombre = txtNombre.Text;
                    pelicula.Descripcion = txtDescripcion.Text;
                    pelicula.Categoria = comboBoxCategoria.Text;
                    pelicula.Precio = int.Parse(txtPrecio.Text);
                    //Llamamos al método ModificarPelicula del controlador para aplicar los cambios en la base de datos
                    controlador.ModificarPelicula(pelicula);
                    //Actualizamos la vista mostrando nuevamente las películas en el dataGridView
                    MostrarPeliculas();
                }
            }
        }
        //Boton Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Verificamos si hay al menos una fila seleccionada en el dataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Obtiene la película asociada a la primera fila seleccionada del dataGridView
                var pelicula = dataGridView1.SelectedRows[0].DataBoundItem as Pelicula;
                //Verificamos si se pudo obtener una referencia válida a la película
                if (pelicula != null)
                {
                    //Muestra el Mensaje  
                    MessageBox.Show("Pelicula Eliminada!");
                    
                    //Llamamos al método EliminarPelicula del controlador para eliminar la película de la base de datos
                    controlador.EliminarPelicula(pelicula.PeliculaId);
                    //Actualizamos la vista mostrando nuevamente las películas en el dataGridView
                    MostrarPeliculas(); 
                }
            }
        }
        //Boton Salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Cierra el formulario actual
            this.Close();

            //Boton Limpiar
            //txtNombre.Text = "";
            //txtDescripcion.Text = "";
            //txtPrecio.Text = "";
            //comboBoxCategoria.Text = "";
        }



     
    }
}
