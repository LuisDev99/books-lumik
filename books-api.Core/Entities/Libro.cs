using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_api.Core.Entities
{
    public class Libro
    {
        public int Id { get; set; }

        public int AutorId { get; set; }

        public string Nombre { get; set; }

        public Autor Autor { get; set; }

        public DateTime FechaPublicacion { get; }

        public int CantidadCopias { get; set; }




    }
}
