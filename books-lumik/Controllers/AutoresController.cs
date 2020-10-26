using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Core.Entities;
using books_lumik.Infrastructure;
using books_lumik.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace books_lumik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly books_lumikDbContext _dbCxt;

        public AutoresController(books_lumikDbContext _context)
        {
            _dbCxt = _context;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public ActionResult<IEnumerable<AutorDto>> Get()
        {
            var autoresDb = _dbCxt.Autores.Select(autor => new AutorDto
            {
                Id = autor.Id,
                Edad = autor.Edad,
                Nombre = autor.Nombre,
            });            

            return Ok(autoresDb);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public ActionResult<AutorDto> Get(int id)
        {
            var autorDb = _dbCxt.Autores.FirstOrDefault(autor => autor.Id == id);

            if (autorDb == null)
            {
                return NotFound("Autor no existe");
            }

            AutorDto autorDto = new AutorDto{ Id = autorDb.Id, Edad = autorDb.Edad, Nombre = autorDb.Nombre};

            return Ok(autorDto); 
        }

        [HttpGet("{nombreAutor}/libros")]
        public ActionResult<IEnumerable<LibroDto>> GetBooks(string nombreAutor)
        {
            var autorDb = _dbCxt.Autores.FirstOrDefault(autor => autor.Nombre == nombreAutor);

            if(autorDb == null)
            {
                return NotFound("Autor: " + nombreAutor + " no existe");
            }

            var librosAutor = _dbCxt.Libros.Select(libro => new LibroDto {
                Id = libro.Id,
                CantidadCopias = libro.CantidadCopias,
                FechaPublicacion = libro.FechaPublicacion,
                Nombre = libro.Nombre,
            }).Where(libro => libro.Id == autorDb.Id);


            return Ok(librosAutor);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public ActionResult<AutorDto> Post([FromBody] AñadirAutor nuevoAutor)
        {
            var autor = _dbCxt.Autores.Add(new Autor
            {
                Edad = nuevoAutor.Edad,
                Nombre = nuevoAutor.Nombre,                                
            });

            _dbCxt.SaveChanges();

            return Ok(new AutorDto
            {
                Id = autor.Entity.Id,
                Edad = autor.Entity.Edad,
                Nombre = autor.Entity.Nombre,
            });
        }
       
    }
}
