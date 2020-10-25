using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_lumik.Models
{
    public class AutorDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int Edad { get; set; }

        public IEnumerable<LibroDto> Libros { get; set; }
    }
}
