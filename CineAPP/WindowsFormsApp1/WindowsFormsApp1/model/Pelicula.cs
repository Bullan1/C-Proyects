using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.model
{
    //Cambiamos la Clase a public
    public class Pelicula
    {
        //Definir Atributos
        //Creamos obligatoriamente una ID Autoincrementable
        public int PeliculaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public string Categoria { get; set;}
        public int Precio { get; set;}



    }
}
