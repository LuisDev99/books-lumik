using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_lumik.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace books_lumik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
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

        [HttpGet("{nombreAutor}/libros")]
        public ActionResult<IEnumerable<LibroDto>> GetBooks(string nombreAutor)
        {

            return Ok("Esta bien: " + nombreAutor);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] AñadirAutor nuevoAutor)
        {

        }
       
    }
}
