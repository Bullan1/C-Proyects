using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Llamamos a la carpeta model
using WindowsFormsApp1.model;

namespace WindowsFormsApp1.controller
{
    public class OperacionesCRUD
    {
        //Traemos la conexion de la BDD
        public ApplicationDbContext conexion;
        //Creamos un constructor
        public  OperacionesCRUD()
        {
            //Iniciamos LA  conexion a BDD
            conexion = new ApplicationDbContext();
        }
        //Metodo Agregar
        public void AgregarPelicula(Pelicula nuevaPelicula)
        {
            //Agrego la nueva pelicula a la bdd
            conexion.Pelicula.Add(nuevaPelicula);
            //Guardar cambios
            conexion.SaveChanges();
        }
        //Metodo Eliminar
        public void EliminarPeliculas(int id)
        {
            //Busca la pelicula segun su id
            var peliculaEliminar = conexion.Pelicula.Find(id);
            if (peliculaEliminar != null)
            {
                //Elimina la pelicula segun su id
                conexion.Pelicula.Remove(peliculaEliminar);
                conexion.SaveChanges();
            }
        }
        //Metodo Modificar
        public void ModificarPeliculas(Pelicula peliculaModificada)
        {
            //Actualizo la pelicula de la bdd
            conexion.Entry(peliculaModificada).State = System.Data.Entity.EntityState.Modified;
            conexion.SaveChanges();
        }

    }
}
