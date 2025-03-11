using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Tramos la Libreria de EntityFramework
using System.Data.Entity;

namespace CarteleraCine.Model
{
    //Cambiamos la clase por publica
    //Heredamos el elemento DbContext para poder interactuar con la base de datos
    public class ApplicationDbContext : DbContext
    {
        //Utilizamos DbSet para representar una tabla con la clase Pelicula
        public DbSet<Pelicula> Pelicula { get; set; }

        //Creamos la Cadena de Conexion para la base de datos
        //Data Source: nombre del servidor
        //Initial Catalog: Nombre de la base de datos
        //Integrated Securiry: Tipo de autenticacion por defecto en windows autentication
        public ApplicationDbContext() : base("Data Source=ALEXIS; Initial Catalog=Cine; Integrated Security=True;")
        {
        }

    }
}
  