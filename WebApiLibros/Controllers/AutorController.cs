using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApiLibros.Data;
using WebApiLibros.Models;

namespace WebApiLibros.Controllers
{
    // api/Autor
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        // esta configuración es lo que se llama inyección de dependencias:

        //propiedad

        private readonly DBLibrosBootcampContext context;

        //constructor

        public AutorController(DBLibrosBootcampContext context)
        {
            this.context = context;
        }
        // acá termina la inyección de dependencias

        //traer todos
        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.ToList();
        }

        //traer por id
        // GET api/autor/{id}
        [HttpGet("{id}")]
        public ActionResult<Autor> GetById(int id)
        {
            Autor autor = (from a in context.Autores
                           where a.IdAutor == id
                           select a).SingleOrDefault();

            return autor;
        }

        //insertar un autor
        //POST api/autor
        [HttpPost]
        public ActionResult Post(Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Autores.Add(autor);

            context.SaveChanges();

            return Ok(); // el Ok es código 200
        }

        //actualizar uno por id
        //UPDATE 
        //PUT api/autor/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Autor autor)
        {
            if (id != autor.IdAutor)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;

            context.SaveChanges();

            return Ok();
        }
        //eliminar uno por id
        //DELETE api/autor/{id}
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = (from a in context.Autores
                         where a.IdAutor == id
                         select a).SingleOrDefault();

            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);

            context.SaveChanges();

            return autor;
        }

        //GET
        // api/autor/listado/{edad}
        [HttpGet("listado/{edad}")]
        public ActionResult<IEnumerable<Autor>> GetEdad(int edad)
        {
            List<Autor> autores = (from a in context.Autores where a.Edad == edad select a).ToList();

            return autores;
        }

    }
}
