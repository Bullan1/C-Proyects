using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarteleraCine.Model
{
    //Cambiamos la clase internal por public
    public class Pelicula
    {
        //Definimos los Atributos de la Clase

        //Definimos Obligariamente el Id de la Pelicula de esa forma
        //Nombre de la clase y el Id por eso PeliculaID
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public int Precio { get; set; }
    }
}
