using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_lumik.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace books_lumik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("prestar_libro")]
        public ActionResult<IEnumerable<LibroDto>> PrestarLibro()
        {

            return Ok("Esta bien");
        }


        [HttpPost("retornar_libro")]
        public ActionResult<IEnumerable<LibroDto>> RetornarLibro()
        {

            return Ok("Esta bien");
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] AñadirLibro nuevoAutor)
        {

        }
    }
}
