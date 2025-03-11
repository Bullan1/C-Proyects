using CarteleraCine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleraCine.Controller
{   
    //Cambiamos la Clase por publica
    public class PeliculaController
    { 
        //Traemos la conexion de base de datos
        public ApplicationDbContext dbContext;

        //Creamos un Contructor
        public PeliculaController()
        {
            //Inicializamos el contexto de la base de datos
            dbContext = new ApplicationDbContext();
        }

        //Metodo Agregar
        public void AgregarPelicula(Pelicula nuevaPelicula)
        {
            //Agregar la nueva película al contexto de la base de datos
            dbContext.Pelicula.Add(nuevaPelicula);
            //Guardar los cambios en la base de datos
            dbContext.SaveChanges();
        } 
        //Metodo Modificar
        public void ModificarPelicula(Pelicula peliculaModificada)
        {
            // Actualizar la película en el contexto de la base de datos
            dbContext.Entry(peliculaModificada).State = System.Data.Entity.EntityState.Modified;
            // Guardar los cambios en la base de datos
            dbContext.SaveChanges();
        }

        //Metodo Eliminar
        public void EliminarPelicula(int id)
        {
            //Buscar la película por su ID en la base de datos
            var peliculaAEliminar = dbContext.Pelicula.Find(id);
            if (peliculaAEliminar != null)
            {
                //Eliminar la película del contexto de la base de datos
                dbContext.Pelicula.Remove(peliculaAEliminar);
                //Guardar los cambios en la base de datos
                dbContext.SaveChanges();
            }

        }
    }
}
