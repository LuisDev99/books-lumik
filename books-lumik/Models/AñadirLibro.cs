using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_lumik.Models
{
    public class AñadirLibro
    {
        public string Nombre { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public AutorDto Autor { get; set; }

        public int CantidadCopias { get; set; }
    }
}
