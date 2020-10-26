using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_api.Core.Entities;
using books_lumik.Infrastructure;
using books_lumik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_lumik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly books_lumikDbContext _dbCxt;

        public LibrosController(books_lumikDbContext dbCxt)
        {
            _dbCxt = dbCxt;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        public ActionResult<IEnumerable<LibroDto>> Get()
        {
            return Ok(_dbCxt.Libros.Select(libroDb => new LibroDto {
                Id = libroDb.Id,
                Nombre = libroDb.Nombre,
                CantidadCopias = libroDb.CantidadCopias,
                FechaPublicacion = libroDb.FechaPublicacion,
            }));
        }

        // GET api/<LibrosController>/5
        [HttpGet("{id}")]
        public ActionResult<LibroDto> Get(int id)
        {
            var libroDb = _dbCxt.Libros.FirstOrDefault(libro => libro.Id == id);

            if (libroDb == null)
            {
                return NotFound("Libro no existe");
            }

            return new LibroDto
            {
                Id = libroDb.Id,
                Nombre = libroDb.Nombre,
                CantidadCopias = libroDb.CantidadCopias,
                FechaPublicacion = libroDb.FechaPublicacion,
            };
        }

        [HttpPost("{id}/prestar-libro")]
        public ActionResult<IEnumerable<LibroDto>> PrestarLibro(int id)
        {
            var libroDb = _dbCxt.Libros.FirstOrDefault(libro => libro.Id == id);            

            if (libroDb == null)
            {
                return NotFound("Not Found");
            }

            if(libroDb.CantidadCopias > 3)
            {
                libroDb.CantidadCopias--;
                _dbCxt.SaveChanges();

                return Ok(new LibroDto {
                    Id = libroDb.Id,
                    Nombre = libroDb.Nombre,
                    CantidadCopias = libroDb.CantidadCopias,
                    FechaPublicacion = libroDb.FechaPublicacion,                  
                });

            } else
            {                
                return NotFound("No hay suficientes copias disponibles");
            }

        }


        [HttpPost("{id}/retornar-libro")]
        public ActionResult<LibroDto> RetornarLibro(int id)
        {
            var libroDb = _dbCxt.Libros.FirstOrDefault(libro => libro.Id == id);

            if (libroDb == null)
            {
                return NotFound("Not Found");
            }
            
            libroDb.CantidadCopias++;
            _dbCxt.SaveChanges();

            return Ok(new LibroDto
            {
                Id = libroDb.Id,
                Nombre = libroDb.Nombre,
                CantidadCopias = libroDb.CantidadCopias,
                FechaPublicacion = libroDb.FechaPublicacion,
            });
            
        }

        // POST api/<LibrosController>
        [HttpPost]
        public ActionResult<LibroDto> Post([FromBody] AñadirLibro nuevoAutor)
        {
            var autor = _dbCxt.Libros.Add(new Libro {
                Nombre = nuevoAutor.Nombre,
                AutorId = nuevoAutor.IdAutor,
                CantidadCopias = nuevoAutor.CantidadCopias,
            });


            _dbCxt.SaveChanges();

            return Ok(new LibroDto
            {
                Id = autor.Entity.Id,
                Nombre = autor.Entity.Nombre,
                CantidadCopias = autor.Entity.CantidadCopias,
                FechaPublicacion = autor.Entity.FechaPublicacion,
            });
        }
    }
}
