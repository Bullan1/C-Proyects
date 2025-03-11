using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Llamamos a la libreria de Entity
using System.Data.Entity;

namespace WindowsFormsApp1.model
{
    public class ApplicationDbContext : DbContext
    {
        //Utilizamos DbSet para representar una tabla con la clase Pelicula
        public DbSet<Pelicula> Pelicula { get; set; }
        //Creamos la cadena de conexion para la base de datos
        //Data Source: Nombre del Servidor
        //Initial CAtalog: Nombre BDD
        //Integrated Security= Tipo de autenticacion por defecto Windows Autentication
        public ApplicationDbContext():base("Data Source=SCL076PCL7022\\SQLEXPRESS; Initial Catalog=cine;Integrated Security=True;")
        {

        }
    }
}
